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
    public class EfGenericRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly KutlarizContext _context;

        public EfGenericRepository(KutlarizContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var entity = await _context.Set<T>().FindAsync(Id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ?
                await _context.Set<T>().ToListAsync() :
                await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
