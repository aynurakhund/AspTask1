using Microsoft.EntityFrameworkCore;
using MovieApp.Entities;
using System.Reflection;

namespace MovieApp.Context
{
    public class MovieContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=MovieAppDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Directors> Directorss { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }
        public DbSet<Imdb> Imdbs { get; set; }
   
        public DbSet<MovieSubtitle> MovieSubtitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
