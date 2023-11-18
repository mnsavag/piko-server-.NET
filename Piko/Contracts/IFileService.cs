using Piko.Models;

namespace Piko.Contracts
{
    public interface IFileService
    {
        public Task<string> CreateFile(IFormFile file, 
            string rootSystemPath, 
            string pathToServerDir);

        public ContestFiles GetPathsToSaveContestImage(int? userId, int? contestId);
    }
}