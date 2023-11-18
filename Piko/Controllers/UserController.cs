using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Piko.DTO;
using Piko.Services;
using Piko.Contracts;


namespace Piko.Controllers
{
    [Route("api/user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateDto userCreateDto)
        {
            var result = await _userService.CreateUser(userCreateDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUser(id);
            if (result == null)
                return NotFound("User not found");
            return Ok(result);
        }
    }
}