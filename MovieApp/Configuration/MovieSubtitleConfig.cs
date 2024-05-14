using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Entities;

namespace MovieApp.Configuration
{
    public class MovieSubtitleConfig : IEntityTypeConfiguration<MovieSubtitle>
    {
        public void Configure(EntityTypeBuilder<MovieSubtitle> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.SubtitleId });
            builder.HasOne(x => x.Movies)
                .WithMany(x => x.MovieSubtitles)
                .HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.Subtitles)
                .WithMany(x => x.MovieSubtitles)
                .HasForeignKey(x => x.SubtitleId);
        }
    }
}
