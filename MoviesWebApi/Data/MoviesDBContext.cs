using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Models;

namespace MoviesWebApi.Data
{
    public class MoviesDBContext :DbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
