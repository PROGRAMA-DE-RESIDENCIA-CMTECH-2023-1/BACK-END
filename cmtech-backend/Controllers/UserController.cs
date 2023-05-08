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
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _userService.FindAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto createUser)
        {
            return Ok(await _userService.Create(createUser));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto updateUser)
        {
            return Ok(await _userService.Update(updateUser));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _userService.Delete(id));
        }
    }
}
