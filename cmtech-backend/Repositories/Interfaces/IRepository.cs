﻿using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<List<T>> FindAll();

        public Task<T?> FindById(int? id);

        public Task<T?> FindByName(string name);

        public Task<T> Create(T item);

        public Task<T> Update(T item);

        public Task<List<T>> Delete(int id);
    }
}
