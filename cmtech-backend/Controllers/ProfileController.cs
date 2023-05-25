using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace cmtech_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet, Authorize]
        public async Task<List<Profile>> FindAll()
        {
            return await _profileService.FindAll();
        }

        [HttpPost, Authorize(Roles = "Administrador")]
        public async Task<Profile> Create(ProfileDto profile)
        {
            return await _profileService.Create(profile);
        }

        [HttpPut, Authorize(Roles = "Administrador")]
        public async Task<Profile> Update(ProfileDto profile)
        {
            return await _profileService.Update(profile);
        }

        [HttpDelete, Authorize(Roles = "Administrador")]
        public async Task<List<Profile>> Delete(int id)
        {
            return await _profileService.Delete(id);
        }
    }
}
