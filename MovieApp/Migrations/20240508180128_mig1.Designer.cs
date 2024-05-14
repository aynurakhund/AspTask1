﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.Context;

#nullable disable

namespace MovieApp.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20240508180128_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieApp.Entities.Directors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Directorss");
                });

            modelBuilder.Entity("MovieApp.Entities.Imdb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("ImdbPoint")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Imdbs");
                });

            modelBuilder.Entity("MovieApp.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieApp.Entities.MovieImdb", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ImdbId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ImdbId");

                    b.HasIndex("ImdbId");

                    b.ToTable("MovieImdbs");
                });

            modelBuilder.Entity("MovieApp.Entities.MovieSubtitle", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("SubtitleId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "SubtitleId");

                    b.HasIndex("SubtitleId");

                    b.ToTable("MovieSubtitles");
                });

            modelBuilder.Entity("MovieApp.Entities.Subtitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Subtitles");
                });

            modelBuilder.Entity("MovieApp.Entities.Movie", b =>
                {
                    b.HasOne("MovieApp.Entities.Directors", "Directorss")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Directorss");
                });

            modelBuilder.Entity("MovieApp.Entities.MovieImdb", b =>
                {
                    b.HasOne("MovieApp.Entities.Imdb", "Imdbs")
                        .WithMany("MovieImdbs")
                        .HasForeignKey("ImdbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.Entities.Movie", "Movies")
                        .WithMany("MovieImdbs")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imdbs");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieApp.Entities.MovieSubtitle", b =>
                {
                    b.HasOne("MovieApp.Entities.Movie", "Movies")
                        .WithMany("MovieSubtitles")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.Entities.Subtitle", "Subtitles")
                        .WithMany("MovieSubtitles")
                        .HasForeignKey("SubtitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");

                    b.Navigation("Subtitles");
                });

            modelBuilder.Entity("MovieApp.Entities.Directors", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieApp.Entities.Imdb", b =>
                {
                    b.Navigation("MovieImdbs");
                });

            modelBuilder.Entity("MovieApp.Entities.Movie", b =>
                {
                    b.Navigation("MovieImdbs");

                    b.Navigation("MovieSubtitles");
                });

            modelBuilder.Entity("MovieApp.Entities.Subtitle", b =>
                {
                    b.Navigation("MovieSubtitles");
                });
#pragma warning restore 612, 618
        }
    }
}
