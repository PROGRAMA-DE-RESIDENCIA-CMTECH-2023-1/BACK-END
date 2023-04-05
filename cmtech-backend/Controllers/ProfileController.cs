using cmtech_backend.Models;
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

        [HttpGet(Name = "GetProfiles")]
        public async Task<List<Profile>> Get()
        {
            return await _profileService.GetProfiles();
        }
    }
}
