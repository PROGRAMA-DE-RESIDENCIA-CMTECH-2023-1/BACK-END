using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class LoginServiceImpl : ILoginService
    {
        private readonly IRepository<User> _userRepository;

        public LoginServiceImpl(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            if (BCrypt.Net.BCrypt.Verify(loginDto.password, _userRepository.FindByName(loginDto.email).Result.Password))
                return true;
            return false;
        }
    }
}
