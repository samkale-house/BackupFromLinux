using System;
using Microsoft.EntityFrameworkCore;
using SampleDataAccessProj.Data.Models;

namespace SampleDataAccessProj.Data
{
    public class AppDbContext : DbContext
    {
         private const string connectionString = "Server=localhost:1433;Database=MovieDB;User Id=sa;Password=SAadmin123;";  
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
        {  
            optionsBuilder.UseSqlServer(connectionString);  
        }  
        public DbSet<Product> products { get; set; }
    }
}
