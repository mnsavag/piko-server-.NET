using Piko.Database;
using Piko.DTO;
using Piko.Exceptions;
using Piko.Contracts;
using Piko.Models.Entities;


namespace Piko.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUser(UserCreateDto dto)
        {
            User user = new()
            {
                Username = dto.UserName,
                Password = dto.Password,
                EMail = dto.Email,
                CreatedDate = DateTime.UtcNow
            };

            var existingUser = _context.Users.Where(u => u.EMail == dto.Email).ToList();
            if (existingUser.Count() != 0)
            {
                throw new AlreadyExistException($"User with mail ${dto.Email} already exist");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<UserDetailDto?> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return null;

            return new UserDetailDto
            {
                Id = user.Id,
                Username = user.Username,
                EMail = user.EMail,
                CreatedDate = user.CreatedDate,
                Contests = user.Contests,
                ContestsLiked = user.ContestsLiked,
                ContestsPassed = user.ContestsPassed
            };
        }
    }
}