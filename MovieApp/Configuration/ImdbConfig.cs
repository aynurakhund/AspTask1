using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Entities;

namespace MovieApp.Configuration
{
    public class ImdbConfig : IEntityTypeConfiguration<Imdb>
    {
        public void Configure(EntityTypeBuilder<Imdb> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.ImdbPoint)
                .IsRequired();
        }
    }
}
