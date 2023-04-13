using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<List<Profile>> FindAll()
        {
            return await _profileService.FindAll();
        }

        [HttpPost]
        public async Task<Profile> Create(CreateProfile profile)
        {
            return await _profileService.Create(profile);
        }

        [HttpPut]
        public async Task<Profile> Update(int id, CreateProfile profile)
        {
            return await _profileService.Update(id,profile);
        }

        [HttpDelete]
        public async Task<List<Profile>> Delete(int id)
        {
            return await _profileService.Delete(id);
        }
    }
}
