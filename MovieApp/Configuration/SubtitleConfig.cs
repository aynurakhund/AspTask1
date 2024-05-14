using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Entities;

namespace MovieApp.Configuration
{
    public class SubtitleConfig : IEntityTypeConfiguration<Subtitle>
    {
        public void Configure(EntityTypeBuilder<Subtitle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Language)
                .HasColumnType("nvarchar(30)")
                .IsRequired();
        }
    }
}
