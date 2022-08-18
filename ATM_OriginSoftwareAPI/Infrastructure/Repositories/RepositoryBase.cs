using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        public ATMContext repositoryContext { get; set; }
        public RepositoryBase(ATMContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public IQueryable<T> GetAll()
        {
            return repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public T Insert(T entity)
        {
            repositoryContext.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            repositoryContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            repositoryContext.Set<T>().Update(entity);
        }
    }
}
