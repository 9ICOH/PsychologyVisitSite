
namespace PsychologyVisitSite.Domain.Abstract
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();
        bool Any(Expression<Func<T, bool>> predicate);

        int Count { get; }

        T Create(T t);

        int Delete(T t);

        int Delete(Expression<Func<T, bool>> predicate);

        T Find(params object[] keys);

        T Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, int index, int size);

        T LastOrDefault();

        int Update(T t);
    }
}
