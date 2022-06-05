using Domain;
using Domain.Repositories;
using Domain.SeedWork;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        private readonly WriteContext _context;

        public UserRepository(WriteContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public Task<List<User>> FindAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}