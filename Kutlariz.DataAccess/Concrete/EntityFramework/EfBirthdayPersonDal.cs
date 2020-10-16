using Kutlariz.Core.Utilities.Helpers;
using Kutlariz.DataAccess.Abstract;
using Kutlariz.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutlariz.DataAccess.Concrete.EntityFramework
{
    public class EfBirthdayPersonDal : EfGenericRepository<BirthdayPerson>, IBirthdayPersonDal
    {
        public EfBirthdayPersonDal(KutlarizContext context) : base(context)
        {
        }

        public async Task<List<BirthdayPerson>> GetClosestThree(string userId)
        {
            var entities = await _context.BirthdayPersons.Where(i => i.UserId == userId)
            .AsNoTracking()
                .ToListAsync();

            return entities.OrderBy(i => CalculateDaysLeftTillNextBday.Calculate(i.Birthday))
                .Take(3).ToList();
        }
    }
}
