
using Microsoft.EntityFrameworkCore;
using System;

namespace FileIOProject.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<Report> UserReports { get; set; }

    }
}