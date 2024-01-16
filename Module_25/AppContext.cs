using Microsoft.EntityFrameworkCore;
using Module_25.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-10HPMU9\SQLEXPRESS;Database=Module_25;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
