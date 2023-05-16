using cmtech_backend.Exceptions;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;

namespace cmtech_backend.Repositories.Implementations
{
    public class UserRepositoryImpl : IRepository<User>
    {

        private readonly DataContext _dbContext;
        private readonly DbSet<User> _users;

        public UserRepositoryImpl(DataContext dbContext)
        {
            _dbContext = dbContext;
            _users = _dbContext.Set<User>();
        }

        public async Task<User> Create(User user)
        {
            if (await _users.AnyAsync(u => u.Id == user.Id))
            {
                throw new InvalidOperationException("Usuário já cadastrado"); 
            }
            await _users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> Delete(int id)
        {
            User user = await FindById(id);
            _users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return await FindAll();
        }

        public async Task<User?> FindById(int? id)
        {
            if (id == null) return null;
            User? user = await _users.FindAsync(id);
            return user ?? throw new NotFoundException("Usuário não encontrado");
        }

        public async Task<List<User>> FindAll()
        {
            return await _users.Include(u => u.Department).Include(u => u.Org).Include(u => u.Profile).ToListAsync();
        }

        public async Task<User?> FindByName(string name)
        {
            return await _users.Include(u => u.Department).Include(u => u.Org).Include(u => u.Profile).FirstAsync(u => u.Email == name);
        }

        public async Task<User> Update(User user)
        {
            User oldUser = await FindById(user.Id);
            _users.Entry(oldUser).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
