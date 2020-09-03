using Kutlariz.Core.Utilities.Helpers;
using Kutlariz.DataAccess.Abstract;
using Kutlariz.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutlariz.DataAccess.Concrete.EntityFramework
{
    public class EfBirthdayPersonDal<TContext> : EfGenericRepository<BirthdayPerson, TContext>, IBirthdayPersonDal
        where TContext : DbContext, new()
    {
        public async Task<List<BirthdayPerson>> GetClosestThree(string userId)
        {
            using var context = new TContext();
            var entities = await context.Set<BirthdayPerson>().Where(i => i.UserId == userId)
                .AsNoTracking()
                .ToListAsync();

            return entities.OrderBy(i => CalculateDaysLeftTillNextBday.Calculate(i.Birthday))
                .Take(3).ToList();
        }
    }
}

//DateTime.Now.DayOfYear - i.Birthday.DayOfYear == 0 ?
//                                       DateTime.Now.DayOfYear - i.Birthday.DayOfYear :

//                                       DateTime.Now.DayOfYear - i.Birthday.DayOfYear< 0 ?
//                                       (DateTime.Now.DayOfYear - i.Birthday.DayOfYear) * -1 :
//                                       366 - (DateTime.Now.DayOfYear - i.Birthday.DayOfYear)
