using Kutlariz.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.DataAccess.Concrete.EntityFramework
{
    public class KutlarizContext : DbContext
    {
        public KutlarizContext(DbContextOptions<KutlarizContext> options) : base(options)
        {

        }

        public DbSet<BirthdayPerson> BirthdayPersons { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
