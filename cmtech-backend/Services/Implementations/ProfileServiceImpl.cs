using cmtech_backend.Models;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class ProfileServiceImpl : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileServiceImpl(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<List<Profile>> GetProfiles()
        {
            return await _profileRepository.GetProfiles();
        }
    }
}
