using cmtech_backend.Models.Converter.Implementations;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;

namespace cmtech_backend.Services.Implementations
{
    public class DepartmentServiceImpl : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        private readonly IRepository<Org> _orgRepository;

        private readonly DepartmentConverter _departmentConverter;
        
        public DepartmentServiceImpl(IRepository<Department> departmentRepository, IRepository<Org> orgRepository)
        {
            _departmentRepository = departmentRepository;
            _orgRepository = orgRepository;
            _departmentConverter = new DepartmentConverter();
        }

        public async Task<List<DepartmentDto>> FindAll()
        {
            List<Department> departments =  await _departmentRepository.FindAll();
            List<DepartmentDto> departmentsDto = _departmentConverter.Parse(departments);
            departmentsDto.ForEach(d => d.Org = _orgRepository.FindById(d.Org_id).Result.Name);
            return departmentsDto;
        }

        public async Task<DepartmentDto> Create(DepartmentDto departmentDto)
        {
            Org org = await _orgRepository.FindById(departmentDto.Org_id);
            Department department = _departmentConverter.Parse(departmentDto);
            department.Org = org;
            Department newDepartment = await _departmentRepository.Create(department);
            return _departmentConverter.Parse(newDepartment);
        }

        public async Task<DepartmentDto> Update(DepartmentDto departmentDto)
        {
            Org org = await _orgRepository.FindById(departmentDto.Org_id);
            Department department = _departmentConverter.Parse(departmentDto);
            department.Org = org;
            Department newDepartment = await _departmentRepository.Update(department);
            return _departmentConverter.Parse(newDepartment);
        }

        public async Task<List<DepartmentDto>> Delete(int id)
        {
            List<Department> departments = await _departmentRepository.Delete(id);
            return _departmentConverter.Parse(departments);
        }

        public async Task<Department?> FindByName(string name)
        {
            return await _departmentRepository.FindByName(name);
        }
    }
}
