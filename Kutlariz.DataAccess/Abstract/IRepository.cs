using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kutlariz.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task Delete(int Id);
        Task Update(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> GetById(int Id);
    }
}
