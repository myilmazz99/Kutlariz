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
            optionsBuilder.UseSqlServer(@"Server=tcp:kutlariz.database.windows.net,1433;Initial Catalog=kutlarizdb;Persist Security Info=False;User ID=admin_kutlariz;Password=Kutmusti230395;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<BirthdayPerson> BirthdayPersons { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
