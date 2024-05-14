using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Entities;
using NuGet.Protocol;

namespace MovieApp.Configuration
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.MovieName)
                .IsRequired();
            builder.Property(x => x.MovieName)
                .HasColumnType("nvarchar(80)")
                .IsRequired();
            builder.Property(x=>x.imageUrl)
                   .HasColumnType("nvarchar(300)");
            builder.HasOne(x => x.Directorss)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.DirectorId);
            builder.HasOne(x => x.Imdbs)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.ImdbId);

        }
    }
}
