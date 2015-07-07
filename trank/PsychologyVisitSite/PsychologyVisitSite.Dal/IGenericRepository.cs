using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PsychologyVisitSite.Dal
{
    public interface IGenericRepository : IDisposable
    {
        bool Any<T>(Expression<Func<T, bool>> predicate) where T: Entity;

        T Create<T>(T t) where T: Entity;

        int Delete<T>(Expression<Func<T, bool>> predicate) where T : Entity;

        int Update<T>(T t) where T: Entity;

        IEnumerable<T> All<T>() where T : Entity;

        T Find<T>(params object[] keys) where T: Entity;

        T Get<T>(Expression<Func<T, bool>> predicate) where T: Entity;

        IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> predicate) where T : Entity;

        IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> predicate, int index, int size) where T : Entity;

        void SaveChanges();
    }
}