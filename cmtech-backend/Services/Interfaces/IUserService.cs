using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> FindAll();

        public Task<UserDto> Create(UserRegisterDto user);

        public Task<User> Update(UserDto user);

        public Task<List<User>> Delete(int id);
    }
}
