using Piko.DTO;

namespace Piko.Contracts
{
    public interface IUserService
    {
        Task<int> CreateUser(UserCreateDto user);
        Task<UserDetailDto?> GetUser(int id);
    }
}
