using Kutlariz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutlariz.DataAccess.Abstract
{
    public interface IBirthdayPersonDal : IRepository<BirthdayPerson>
    {
        Task<List<BirthdayPerson>> GetClosestThree(string userId);
    }
}
