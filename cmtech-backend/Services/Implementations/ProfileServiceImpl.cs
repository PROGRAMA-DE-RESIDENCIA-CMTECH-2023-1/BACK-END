using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
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

        public async Task<Profile> Create(CreateProfile profile)
        {
            Profile newProfile = new Profile(profile.Name);
            return await _profileRepository.Create(newProfile);
        }

        public async Task<Profile> Update(int id,CreateProfile profile)
        {
            Profile newProfile = new Profile(id, profile.Name);
            return await _profileRepository.Update(id,newProfile);
        }

        public async Task<List<Profile>> Delete(int id)
        {
            return await _profileRepository.Delete(id);
        }
    }
}
