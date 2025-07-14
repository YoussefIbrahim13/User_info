using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using user_info.Models;

namespace user_info.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext() { }

        public DbSet<Usermodel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               
                optionsBuilder.UseSqlServer("DESKTOP-K3JIAR0\\SQLEXPRESS01;Database=UserInfoDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}