using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Services.Interfaces
{
    public interface IDepartmentService
    {
        public Task<List<DepartmentDto>> FindAll();

        public Task<DepartmentDto> Create(DepartmentDto departmentDto);

        public Task<DepartmentDto> Update(DepartmentDto departmentDto);

        public Task<List<DepartmentDto>> Delete(int id);

        public Task<Department?> FindByName(string name);
    }
}
