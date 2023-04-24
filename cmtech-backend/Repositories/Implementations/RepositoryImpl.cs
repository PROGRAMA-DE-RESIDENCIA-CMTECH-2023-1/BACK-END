﻿using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;

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

        public async Task<T> Create(T item)
        {
            if (Exists(item.Id) == null)
            {
                throw new InvalidOperationException("Perfil já cadastrado");
            }
            await _dbSet.AddAsync(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<T> Update(T item)
        {
            T? oldItem = await Exists(item.Id);
            if (oldItem == null)
            {
                throw new InvalidOperationException("Perfil não encontrado");
            }
            _dbSet.Entry(oldItem).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return item;
        }
        
        public async Task<List<T>> Delete(int id)
        {
            T? item = await Exists(id);
            if (item == null)
            {
                throw new InvalidOperationException("Perfil não encontrado");
            }
            _dbSet.Remove(item);
            _context.SaveChanges();
            return await FindAll();
        }

        public async Task<T?> Exists(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}