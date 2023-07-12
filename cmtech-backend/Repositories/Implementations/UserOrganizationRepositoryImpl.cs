using cmtech_backend.Exceptions;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;

namespace cmtech_backend.Repositories.Implementations
{
    public class UserOrganizationRepositoryImpl : IUserOrganizationRepository
    {

        private readonly DataContext _dbContext;
        private readonly DbSet<UserOrganization> _userOrganizations;

        public UserOrganizationRepositoryImpl(DataContext dbContext)
        {
            _dbContext = dbContext;
            _userOrganizations = _dbContext.Set<UserOrganization>();
        }

        public async Task<UserOrganization> Create(UserOrganization user)
        {
            if (await _userOrganizations.AnyAsync(u => u.UserId == user.UserId && u.OrganizationId == user.OrganizationId))
            {
                throw new InvalidOperationException("Usuário já vinculado a organização");
            }
            await _userOrganizations.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserOrganization>> Delete(int id)
        {
            UserOrganization user = await FindById(id);
            _userOrganizations.Remove(user);
            await _dbContext.SaveChangesAsync();
            return await FindAll();
        }

        public async Task<UserOrganization?> FindById(int? id)
        {
            if (id == null) return null;
            UserOrganization? user = await _userOrganizations.Include(u => u.User).Include(u => u.Org).FirstOrDefaultAsync(u => u.Id == id);
            return user ?? throw new NotFoundException("Organização do usuário não encontrada");
        }

        public async Task<List<UserOrganization>> FindAll()
        {
            return await _userOrganizations.Include(u => u.User).Include(u => u.Org).ToListAsync();
        }

        public async Task<UserOrganization?> FindByName(string name)
        {
            return null;
        }

        public async Task<UserOrganization> Update(UserOrganization user)
        {
            UserOrganization oldUserOrganization = await FindById(user.Id);
            _userOrganizations.Entry(oldUserOrganization).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();
            return user;

        }

        public async Task<List<UserOrganization>> GetAllByUserId(int userId)
        {
            return await _userOrganizations.Include(u => u.Org).Where(u => u.UserId == userId).ToListAsync();
        }
    }
}