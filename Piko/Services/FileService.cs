using Piko.Contracts;
using Piko.Models;


namespace Piko.Services
{
    public class FileService : IFileService
    {
        public async Task<string> CreateFile(IFormFile file, 
            string rootSystemPath, 
            string pathToServerDir)
        {
            string systemPath = Path.Combine(rootSystemPath, pathToServerDir);
            if (!Directory.Exists(systemPath))
            {
                Directory.CreateDirectory(systemPath);
            }
            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;
            var fullSysPath = Path.Combine(systemPath, fileName);
;           
            using (Stream fileStream = new FileStream(fullSysPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Path.Combine(pathToServerDir, fileName);
        }

        public ContestFiles GetPathsToSaveContestImage(int? userId, int? contestId)
        {
            string currPath = Directory.GetCurrentDirectory();
            string rootSysPath = Path.GetFullPath(Path.Combine(currPath, "assets"));

            string contestOwner = userId != null ? userId.ToString() : "community";
            string contestDirName = contestId != null ? contestId.ToString() : Guid.NewGuid().ToString();

            string pathToContest = Path.Combine("contests", contestOwner, contestDirName);
            string pathToPreview = Path.Combine(pathToContest, "preview");
            string pathToOptions = Path.Combine(pathToContest, "options");

            return new ContestFiles
            {
                RootSysPath = rootSysPath,
                ContestDir = pathToContest,
                PreviewDir = pathToPreview,
                OptionsDir = pathToOptions
            };
        }
    }
}