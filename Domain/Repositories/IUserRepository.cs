using Domain.SeedWork;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        void CreateUser(User user);
        Task<List<User>> FindAllUser();
        Task<User> FindOne(Guid userId);
    }
}