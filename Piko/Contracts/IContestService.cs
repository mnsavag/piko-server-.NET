using Microsoft.AspNetCore.Mvc;
using Piko.Dto;
using Piko.Models.Entities;
using static Piko.Dto.ContestDto;


namespace Piko.Contracts
{
    public interface IContestService
    {
        Task<int> CreateContest(ContestCreateDto contestDto);

        Task<Contest> UploadContestImages(int id, ContestUploadImagesDto contestDto);

        Contest? GetContest(int id);

        List<Contest> GetAllAccessContest(string name);

        Contest DeleteContest(int id);

        Task<List<Option>> UpdateOptionVictory(int id, int option);

        List<OptionGetDto> GetOptionsTopList(int id);
    }
}