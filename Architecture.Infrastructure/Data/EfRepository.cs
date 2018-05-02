using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Architecture.Core.Entities;
using Architecture.Core.Interfaces;

namespace Architecture.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;

        public EfRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _dbSet.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await FindAll(predicate).ToListAsync();
        }

        public IQueryable<T> All()
        {
            return _dbSet.AsQueryable();
        }
    }
}