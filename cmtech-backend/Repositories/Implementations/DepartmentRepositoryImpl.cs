using cmtech_backend.Exceptions;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cmtech_backend.Repositories.Implementations
{
    public class DepartmentRepositoryImpl : IRepository<Department>
    {
        private readonly DataContext _context;
        private readonly DbSet<Department> _departments;

        public DepartmentRepositoryImpl(DataContext context)
        {
            _context = context;
            _departments = _context.Set<Department>();
        }

        public async Task<Department> Create(Department department)
        {
            if (await _departments.AnyAsync(d => d.Id == department.Id))
                throw new InvalidOperationException("Departamento já cadastrado");
            await _departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<List<Department>> Delete(int id)
        {
            Department department = await FindById(id);
            _departments.Remove(department);
            await _context.SaveChangesAsync();
            return await FindAll();
        }

        public async Task<List<Department>> FindAll()
        {
            return await _departments.Include(d => d.Org).ToListAsync();
        }

        public async Task<Department?> FindById(int? id)
        {
            if (id == null) return null;
            Department? department = await _departments.FirstOrDefaultAsync(d => d.Id == id);
            return department ?? throw new NotFoundException("Departamento não encontrado");
        }

        public async Task<Department?> FindByName(string name)
        {
            return await _departments.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task<Department> Update(Department department)
        {
            Department oldDepartment = await FindById(department.Id);
            _departments.Entry(oldDepartment).CurrentValues.SetValues(department);
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
