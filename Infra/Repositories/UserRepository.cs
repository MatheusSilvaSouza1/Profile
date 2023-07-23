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
            return await _context.Users.Include(e => e.Addresses).ToListAsync();
        }

        public async Task<List<User>> Find(Expression<Func<User, bool>> condition)
        {
            return await _context.Users.Where(condition).ToListAsync();
        }

        public async Task<User?> FindOne(Expression<Func<User, bool>> condition)
        {
            return await _context.Users.FirstOrDefaultAsync(condition);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public async Task<User?> FindOne(Guid userId)
        {
            return await _context.Users.Include(e => e.Addresses).FirstOrDefaultAsync(e => e.Id == userId);
        }
    }
}