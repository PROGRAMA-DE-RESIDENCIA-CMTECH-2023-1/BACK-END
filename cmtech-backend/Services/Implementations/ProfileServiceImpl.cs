using cmtech_backend.Models;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class ProfileServiceImpl : IProfileService
    {
        private readonly IRepository<Profile> _profileRepository;

        public ProfileServiceImpl(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<List<Profile>> FindAll()
        {
            return await _profileRepository.FindAll();
        }

        public async Task<Profile> Create(Profile profile)
        {
           return await _profileRepository.Create(profile);
        }

        public async Task<Profile> Update(Profile profile)
        {
            return await _profileRepository.Update(profile);
        }

        public async Task<List<Profile>> Delete(int id)
        {
            return await _profileRepository.Delete(id);
        }
    }
}
