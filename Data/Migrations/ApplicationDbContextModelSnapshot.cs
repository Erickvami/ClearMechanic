﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClearMechanic.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<int>("ActorsId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("ActorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("ActorMovie");

                    b.HasData(
                        new
                        {
                            ActorsId = 1,
                            MoviesId = 1
                        },
                        new
                        {
                            ActorsId = 2,
                            MoviesId = 2
                        },
                        new
                        {
                            ActorsId = 3,
                            MoviesId = 2
                        },
                        new
                        {
                            ActorsId = 4,
                            MoviesId = 4
                        },
                        new
                        {
                            ActorsId = 5,
                            MoviesId = 5
                        },
                        new
                        {
                            ActorsId = 6,
                            MoviesId = 3
                        });
                });

            modelBuilder.Entity("ClearMechanic.Data.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageURI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageURI = "https://www.usmagazine.com/wp-content/uploads/2024/01/Stars-Who-Are-Continually-Snubbed-by-the-Oscars-Leonardo-DiCaprio-Margot-Robbie-and-More-4.jpg?w=800&h=1421&crop=1&quality=86&strip=all",
                            IsDeleted = false,
                            Name = "Leonardo DiCaprio",
                            Registered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            ImageURI = "https://hips.hearstapps.com/hmg-prod/images/dl-u560867-033-6690cc8706ad7.jpg?crop=0.6666666666666666xw:1xh;center,top&resize=640:*",
                            IsDeleted = false,
                            Name = "Scarlett Johansson",
                            Registered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            ImageURI = "https://img.europapress.es/fotoweb/fotonoticia_20130716180221_1200.jpg",
                            IsDeleted = false,
                            Name = "Robert Downey Jr.",
                            Registered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            ImageURI = "https://static3.mujerhoy.com/www/multimedia/202401/26/media/cortadas/emma-stone-cambios-look-pelo-kuRH-U2101349567837EqH-1248x1248@MujerHoy.jpg",
                            IsDeleted = false,
                            Name = "Emma Stone",
                            Registered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            ImageURI = "https://es.web.img2.acsta.net/pictures/16/04/26/10/00/472541.jpg",
                            IsDeleted = false,
                            Name = "Tom Hanks",
                            Registered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            ImageURI = "https://es.web.img2.acsta.net/c_310_420/pictures/17/02/06/17/01/343859.jpg",
                            IsDeleted = false,
                            Name = "Keanu Reeves",
                            Registered = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ClearMechanic.Data.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Science Fiction"
                        });
                });

            modelBuilder.Entity("ClearMechanic.Data.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageURI = "https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p7825626_p_v8_ae.jpg",
                            IsDeleted = false,
                            Registered = new DateTime(2024, 8, 20, 13, 22, 7, 504, DateTimeKind.Local).AddTicks(9769),
                            Title = "Inception"
                        },
                        new
                        {
                            Id = 2,
                            ImageURI = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_.jpg",
                            IsDeleted = false,
                            Registered = new DateTime(2024, 8, 20, 13, 22, 7, 504, DateTimeKind.Local).AddTicks(9822),
                            Title = "Avengers: Endgame"
                        },
                        new
                        {
                            Id = 3,
                            ImageURI = "https://c8.alamy.com/comp/PXNB40/matrix-original-movie-poster-PXNB40.jpg",
                            IsDeleted = false,
                            Registered = new DateTime(2024, 8, 20, 13, 22, 7, 504, DateTimeKind.Local).AddTicks(9824),
                            Title = "The Matrix"
                        },
                        new
                        {
                            Id = 4,
                            ImageURI = "https://pics.filmaffinity.com/la_la_land-262021831-mmed.jpg",
                            IsDeleted = false,
                            Registered = new DateTime(2024, 8, 20, 13, 22, 7, 504, DateTimeKind.Local).AddTicks(9826),
                            Title = "La La Land"
                        },
                        new
                        {
                            Id = 5,
                            ImageURI = "https://m.media-amazon.com/images/I/91++WV6FP4L._AC_UF894,1000_QL80_.jpg",
                            IsDeleted = false,
                            Registered = new DateTime(2024, 8, 20, 13, 22, 7, 504, DateTimeKind.Local).AddTicks(9828),
                            Title = "Forrest Gump"
                        });
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");

                    b.HasData(
                        new
                        {
                            GenresId = 1,
                            MoviesId = 1
                        },
                        new
                        {
                            GenresId = 2,
                            MoviesId = 2
                        },
                        new
                        {
                            GenresId = 2,
                            MoviesId = 3
                        },
                        new
                        {
                            GenresId = 3,
                            MoviesId = 4
                        },
                        new
                        {
                            GenresId = 4,
                            MoviesId = 5
                        });
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("ClearMechanic.Data.Models.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClearMechanic.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("ClearMechanic.Data.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClearMechanic.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
