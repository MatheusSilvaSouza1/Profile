using Domain.SeedWork;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public void CreateUser(User user);
        public Task<List<User>> FindAllUser();
        public Task<User> FindOne(string userId);
    }
}