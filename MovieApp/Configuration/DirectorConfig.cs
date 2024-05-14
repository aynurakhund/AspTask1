using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Entities;

namespace MovieApp.Configuration
{
    public class DirectorConfig : IEntityTypeConfiguration<Directors>
    {
        public void Configure(EntityTypeBuilder<Directors> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .HasColumnType("nvarchar(80)")
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

        }
    }
}
