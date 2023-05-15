using cmtech_backend.Models.Dtos;

namespace cmtech_backend.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<bool> Login(LoginDto loginDto);
    }
}
