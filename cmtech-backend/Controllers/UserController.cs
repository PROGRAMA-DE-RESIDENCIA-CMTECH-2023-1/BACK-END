using cmtech_backend.Exceptions;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new();
            string randomPassword = new(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            createUser.Password = randomPassword;
            UserDto user = await _userService.Create(createUser);
            user.Password = randomPassword;
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto updateUser)
        {
            try
            {
                return Ok(await _userService.Update(updateUser));
            } catch (NotFoundException e)
            {
                return NotFound(e.Message);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _userService.Delete(id));
            } catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }
    }
}
