using Piko.Database;
using Piko.Contracts;
using Piko.Models.Entities;
using static Piko.Dto.ContestDto;
using Piko.Exceptions;
using Piko.Dto;


namespace Piko.Services
{
    public class ContestService : IContestService
    {
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IFileService _fileService;

        public ContestService(AppDbContext context, 
            ICategoryService categoryService, 
            IFileService fileService)
        {
            _context = context;
            _categoryService = categoryService;
            _fileService = fileService;
        }

        public async Task<int> CreateContest(ContestCreateDto contestDto)
        {
            var existCategories = _categoryService.GetAll();
            var existCategoryIds = existCategories.Select(c => c.Id).ToList();

            foreach(var id in contestDto.CategoriesIds)
            {
                if (!existCategoryIds.Contains(id))
                {
                    throw new RecordNotFoundException($"Category {id} doesn't exist");
                }
            }

            Contest contest = new(
                contestDto.Name, 
                contestDto.Description, 
                contestDto.Options, 
                existCategories.Where(c => contestDto.CategoriesIds.Contains(c.Id)).ToList());
            
            _context.Contests.Add(contest);
            await _context.SaveChangesAsync();

            return contest.Id;
        }

        public async Task<Contest> UploadContestImages(int id, ContestUploadImagesDto contestDto)
        {
            var contest = GetContest(id) ?? throw new RecordNotFoundException($"User {id} not found");
            if (contest.CanBePublished)
            {
                throw new Exception("Contest already filled");
            }
            if (contest.Options.Count != contestDto.Options.Count)
            {
                throw new Exception("Contest and OptionsFiles length are different\"");
            }

            var paths = _fileService.GetPathsToSaveContestImage(null, id);

            contest.PreviewFirst = await _fileService.CreateFile(contestDto.PreviewFirst,
                paths.RootSysPath,
                paths.PreviewDir);

            contest.PreviewSecond = await _fileService.CreateFile(contestDto.PreviewSecond, 
                paths.RootSysPath,
                paths.PreviewDir);

            for(int i = 0; i < contest.Options.Count; i++)
            {
                contest.Options[i].Image = await _fileService.CreateFile(contestDto.Options[i],
                    paths.RootSysPath,
                    paths.ContestDir);
            }
            contest.CanBePublished = true;
            _context.SaveChanges();
            return contest;
        }

        public Contest? GetContest(int id)
        {
            var contest = _context.Contests.Where(c => c.Id == id).FirstOrDefault();
            return contest;
        }

        public List<Contest> GetAllAccessContest(string name)
        {
            var contests = _context.Contests.Where(c => c.CanBePublished).ToList();
            if (name != "")
            {
                return contests.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            return contests;
        }

        public Contest DeleteContest(int id)
        {
            var contest = GetContest(id) ?? throw new RecordNotFoundException($"Contest with {id} not found");
            _context.Contests.Remove(contest);
            _context.SaveChanges();
            return contest;
        }

        public async Task<List<Option>> UpdateOptionVictory(int id, int optionId)
        {
            var contest = GetContest(id) ?? 
                throw new RecordNotFoundException($"Contest with {id} not found");

            var option = contest.Options.Where(o => o.Id == optionId).FirstOrDefault() ?? 
                throw new Exception($"Option with {optionId} not found");

            option.VictoryCount += 1;

            var totalPassed = 0;
            foreach(var item in contest.Options) 
            {
                totalPassed += item.VictoryCount;
            }
            contest.CountPassed = totalPassed;

            _context.Update(contest); // update JSON
            await _context.SaveChangesAsync();
            return contest.Options;
        }

        public List<OptionGetDto> GetOptionsTopList(int id)
        {
            var contest = GetContest(id) ??
                throw new RecordNotFoundException($"Contest with {id} not found");

            var totalGames = 0;
            foreach (var item in contest.Options)
            {
                totalGames += item.VictoryCount;
            }

            List<OptionGetDto> result = new();
            if (totalGames == 0)
            {
                foreach (var option in contest.Options)
                {
                    result.Add(new OptionGetDto()
                    {
                        Id = option.Id,
                        Name = option.Name,
                        Image = option.Image,
                        VictoryCount = option.VictoryCount,
                        WinRate = 0
                    });
                }
            }
            else
            {
                foreach(var option in contest.Options)
                {
                    double winRate = ((double)option.VictoryCount / totalGames * 100);
                    winRate = Math.Round(winRate, 2);

                    result.Add(new OptionGetDto()
                    {
                        Id = option.Id,
                        Name = option.Name,
                        Image = option.Image,
                        VictoryCount = option.VictoryCount,
                        WinRate = winRate
                    });
                }
            }
            return result.OrderByDescending(o => o.WinRate).ToList();
        }
    }
}