using System.Linq.Expressions;

namespace Domain.SeedWork;

public interface IRepository<T>
    where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
    Task<List<T>> Find(Expression<Func<T, bool>> condition);
    Task<T?> FindOne(Expression<Func<T, bool>> condition);
}