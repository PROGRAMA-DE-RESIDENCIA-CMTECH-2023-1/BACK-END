using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cmtech_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> FindAll()
        {
            return await _userService.FindAll();
        }

        [HttpPost]
        public async Task<User> Create(UserDto createUser)
        {
            return await _userService.Create(createUser);
        }

        [HttpPut]
        public async Task<User> Update(UserDto updateUser)
        {
            return await _userService.Update(updateUser);
        }

        [HttpDelete]
        public async Task<List<User>> Delete(int id)
        {
            return await _userService.Delete(id);
        }
    }
}
