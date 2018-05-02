using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T Get(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> All();
    }
}