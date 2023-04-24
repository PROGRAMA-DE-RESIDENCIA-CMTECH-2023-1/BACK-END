using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<List<Profile>> FindAll();

        public Task<Profile> Create(ProfileDto profile);

        public Task<Profile> Update(ProfileDto profile);

        public Task<List<Profile>> Delete(int id);
    }
}
