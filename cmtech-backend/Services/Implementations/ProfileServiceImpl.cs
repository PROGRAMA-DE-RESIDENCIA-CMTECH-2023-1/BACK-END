using cmtech_backend.Models.Converter.Implementations;
using cmtech_backend.Models.Converter.Interfaces;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;
using System;

namespace cmtech_backend.Services.Implementations
{
    public class ProfileServiceImpl : IProfileService
    {
        private readonly IRepository<Profile> _profileRepository;

        private readonly ProfileConverter _converter;

        public ProfileServiceImpl(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
            _converter = new ProfileConverter();
        }

        public async Task<List<Profile>> FindAll()
        {
            return await _profileRepository.FindAll();
        }

        public async Task<Profile> Create(ProfileDto profile)
        {
            Profile newProfile = _converter.Parse(profile);
            return await _profileRepository.Create(newProfile);
        }

        public async Task<Profile> Update(ProfileDto profile)
        {
            Profile newProfile = _converter.Parse(profile);
            return await _profileRepository.Update(newProfile);
        }

        public async Task<List<Profile>> Delete(int id)
        {
            return await _profileRepository.Delete(id);
        }
    }
}
