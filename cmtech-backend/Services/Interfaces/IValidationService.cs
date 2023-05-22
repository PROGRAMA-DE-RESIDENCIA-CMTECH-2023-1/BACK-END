using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface IValidationService
    {
        public Task<UserDto?> Validate(string token);
    }
}
