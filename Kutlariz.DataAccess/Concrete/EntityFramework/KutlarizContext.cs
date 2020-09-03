using Kutlariz.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.DataAccess.Concrete.EntityFramework
{
    public class KutlarizContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=KutlarizDB; integrated security=true;");
        }

        public DbSet<BirthdayPerson> BirthdayPersons { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
