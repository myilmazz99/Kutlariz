using Kutlariz.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kutlariz.DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public async Task Create(T entity)
        {
            using var context = new TContext();
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            using var context = new TContext();
            var entity = await context.Set<T>().FindAsync(Id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null ?
                await context.Set<T>().ToListAsync() :
                await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            using var context = new TContext();
            return await context.Set<T>().FindAsync(Id);
        }

        public async Task Update(T entity)
        {
            using var context = new TContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
