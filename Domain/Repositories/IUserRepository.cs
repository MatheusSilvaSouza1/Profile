using Domain.SeedWork;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public void CreateUser(User user);
        public Task<User> FindUser(string userId);
        public Task<List<User>> FindAllUser();
    }
}