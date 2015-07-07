using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PsychologyVisitSite.Dal
{
    public class EfDbContext : DbContext
    {
    }


    public class EfGenericRepository : IGenericRepository
    {
        protected readonly bool ShareContext;

        private readonly DbContext _context;

        public EfGenericRepository(DbContext context)
            : this(context, false)
        {
        }

        public EfGenericRepository(DbContext context, bool sharedContext)
        {
            _context = context;
            ShareContext = sharedContext;
        }
        public void Dispose()
        {
            if (!ShareContext && _context != null)
            {
                //  try
                //  {
                _context.Dispose();
                //   }
                //   catch { }

            }
        }

        public bool Any<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            return _context.Set<T>().Any(predicate);
        }

        public T Create<T>(T t) where T : Entity
        {
            _context.Set<T>().Add(t);

            if (!ShareContext)
                _context.SaveChanges();

            return t;
        }

        public int Delete<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            IEnumerable<T> all = FindAll(predicate);
            _context.Set<T>().RemoveRange(all);
            if (!ShareContext)
                return _context.SaveChanges();

            return 0;
        }

        public int Update<T>(T t) where T : Entity
        {
            var entry = _context.Entry(t);            
            _context.Set<T>().Attach(t);

            entry.State = EntityState.Modified;

            if (!ShareContext)
            {
                return _context.SaveChanges();
            }

            return 0;
        }

        public IEnumerable<T> All<T>() where T : Entity
        {
            return _context.Set<T>().Where(x => true);
        }

        public T Find<T>(params object[] keys) where T : Entity
        {
            return _context.Set<T>().Find(keys);
        }

        public T Get<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> predicate, int index, int size) where T : Entity
        {
            var skip = index * size;
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (skip != 0)
            {
                query = query.Skip(skip);
            }

            return query.Take(size).AsQueryable();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
