using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Vehicle.DAL;

namespace Vehicle.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<VehicleMake> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        
        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}