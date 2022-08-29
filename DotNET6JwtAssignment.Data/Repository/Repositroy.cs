using DotNET6JwtAssignment.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNET6JwtAssignment.Data.Repository
{
    public class BaseRepositroy<T>: IRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext;
        public BaseRepositroy(ApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<IQueryable<T>> FindAll(bool trackChanges) =>
            !trackChanges ? await Task.Run(() => _dbContext.Set<T>().AsNoTracking()) : await Task.Run(() => _dbContext.Set<T>());

        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? await Task.Run(() => _dbContext.Set<T>().Where(expression).AsNoTracking()) : await Task.Run(() => _dbContext.Set<T>().Where(expression));

        public async Task Create(T entity) => await Task.Run(() => _dbContext.Set<T>().Add(entity));

        public async Task Update(T entity) => await Task.Run(() => _dbContext.Set<T>().Update(entity));
        public async Task Remove(T entity) => await Task.Run(() => _dbContext.Set<T>().Remove(entity));
    }
}
