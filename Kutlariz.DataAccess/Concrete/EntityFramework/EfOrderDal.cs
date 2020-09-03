using Kutlariz.DataAccess.Abstract;
using Kutlariz.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal<TContext> : EfGenericRepository<Order, TContext>, IOrderDal 
        where TContext : DbContext, new()
    {
    }
}
