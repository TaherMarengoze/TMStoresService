using System;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using EntitiesCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TMStoresContext StoresContext { get; set; }

        public RepositoryBase(TMStoresContext storesContext)
        {
            StoresContext = storesContext;
        }

        public IQueryable<T> FindAll() => StoresContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            => StoresContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => StoresContext.Set<T>().Add(entity);

        public void Update(T entity) => StoresContext.Set<T>().Update(entity);

        public void Delete(T entity) => StoresContext.Set<T>().Remove(entity);
    }
}