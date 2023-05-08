using cmtech_backend.Models.Entitys;

namespace cmtech_backend.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public new Task<List<User>> FindAll();

        public new Task<User> FindById(int id);

        public new Task<User?> FindByName(string name);

        public new Task<User> Create(User user);

        public new Task<User> Update(User user);

        public new Task<List<User>> Delete(int id);
    }
}
