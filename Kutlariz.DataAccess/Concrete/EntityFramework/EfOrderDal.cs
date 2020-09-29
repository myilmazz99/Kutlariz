using Kutlariz.DataAccess.Abstract;
using Kutlariz.Entities;

namespace Kutlariz.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfGenericRepository<Order>, IOrderDal
    {

        public EfOrderDal(KutlarizContext context) : base(context)
        {
        }
    }
}
