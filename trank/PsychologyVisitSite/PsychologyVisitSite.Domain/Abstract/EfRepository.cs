
namespace PsychologyVisitSite.Domain.Abstract
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public abstract class EfRepository<C, T> : IRepository<T>
        where T : class
        where C : DbContext, new()
    {
        private C entities = new C();
        public C Context
        {

            get { return this.entities; }
            set { this.entities = value; }
        }

        protected DbSet<T> DbSet
        {
            get
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<C>());
                return this.Context.Set<T>();
            }
        }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public bool Any(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this.DbSet.Any(predicate);
        }

        public int Count
        {
            get
            {
                return this.DbSet.Count();
            }
        }

        public T Create(T t)
        {
            this.DbSet.Add(t);
            this.Context.SaveChanges();
            return t;
        }

        public int Delete(T t)
        {
            this.DbSet.Remove(t);
            return this.Context.SaveChanges();
        }

        public int Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var records = this.FindAll(predicate);
            foreach (var record in records)
            {
                this.DbSet.Remove(record);
            }

            return this.Context.SaveChanges();
        }

        public T Find(params object[] keys)
        {
            return this.DbSet.Find(keys);
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this.DbSet.SingleOrDefault(predicate);
        }

        public IQueryable<T> FindAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this.DbSet.Where(predicate).AsQueryable();
        }

        public IQueryable<T> FindAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int index, int size)
        {
            var skip = index * size;
            IQueryable<T> query = this.DbSet;

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

        public int Update(T t)
        {
            var entry = this.Context.Entry(t);
            this.DbSet.Attach(t);

            entry.State = EntityState.Modified;
            return this.Context.SaveChanges();
        }

        public T LastOrDefault()
        {
            var en = this.All().AsEnumerable();
            return en.LastOrDefault();
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
    }
}
