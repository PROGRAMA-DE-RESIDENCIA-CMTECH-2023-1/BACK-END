using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using System.Collections.Generic;

namespace cmtech_backend.Repositories.Implementations
{
    public class RepositoryImpl<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryImpl(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> FindAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> FindById(int id)
        {
            T? item = await _dbSet.FindAsync(id);
            return item ?? throw new InvalidOperationException("Item não encontrado");
        }

        public async Task<T> Create(T item)
        {
            if (await FindById(item.Id) != null)
            {
                throw new InvalidOperationException("Perfil já cadastrado");
            }
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Update(T item)
        {
            T oldItem = await FindById(item.Id);
            _dbSet.Entry(oldItem).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return item;
        }
        
        public async Task<List<T>> Delete(int id)
        {
            T item = await FindById(id);
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return await FindAll();
        }

        public async Task<T?> FindByName(string name)
        {
            var items = await FindAll();
            foreach(var t in items)
            {
                if (typeof(T).GetProperty("Name").GetValue(t).Equals(name))
                    return t;
            }
            return null;
        }
    }
}
