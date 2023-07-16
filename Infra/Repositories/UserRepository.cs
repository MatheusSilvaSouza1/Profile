using System.Linq.Expressions;
using Domain;
using Domain.Repositories;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<User>> FindAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> Find(Expression<Func<User, bool>> condition)
        {
            return await _context.Users.Where(condition).ToListAsync();
        }

        public async Task<User?> FindOne(Expression<Func<User, bool>> condition)
        {
            return await _context.Users.FirstOrDefaultAsync(condition);
        }
    }
}