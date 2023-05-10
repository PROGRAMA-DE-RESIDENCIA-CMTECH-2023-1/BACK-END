using cmtech_backend.Exceptions;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;

namespace cmtech_backend.Repositories.Implementations
{
    public class OrgRepositoryImpl : IRepository<Org>
    {
        private readonly DataContext _context;

        private readonly DbSet<Org> _orgs;

        public OrgRepositoryImpl(DataContext context)
        {
            _context = context;
            _orgs = context.Orgs;
        }

        public async Task<Org> Create(Org org)
        {
            if (await _orgs.AnyAsync(o => o.Id == org.Id))
            {
                throw new InvalidOperationException("Organização já cadastrada");
            }
            await _orgs.AddAsync(org);
            await _context.SaveChangesAsync();
            return org;
        }

        public async Task<List<Org>> Delete(int id) 
        {
            Org org = await FindById(id);
            _orgs.Remove(org);
            await _context.SaveChangesAsync();
            return await FindAll();
        }

        public async Task<List<Org>> FindAll()
        {
            return await _orgs.Include(o => o.Group).Include(o => o.Segment).ToListAsync();
        }

        public async Task<Org?> FindById(int? id)
        {
            if (id == null) return null;
            Org org = await _orgs.FirstAsync(o => o.Id == id);
            return org ?? throw new NotFoundException("Organização não encontrada");
        }

        public async Task<Org?> FindByName(string name)
        {
            return await _orgs.FirstAsync(o => o.Name == name);
        }

        public async Task<Org> Update(Org org)
        {
            Org oldOrg = await FindById(org.Id);
            _orgs.Entry(oldOrg).CurrentValues.SetValues(org);
            await _context.SaveChangesAsync();
            return org;
        }
    }
}
