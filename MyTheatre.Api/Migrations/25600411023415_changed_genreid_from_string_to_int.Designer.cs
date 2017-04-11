using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyTheatre.Api.Infrastructure;

namespace MyTheatre.Api.Migrations
{
    [DbContext(typeof(MyTheatreContext))]
    [Migration("25600411023415_changed_genreid_from_string_to_int")]
    partial class changed_genreid_from_string_to_int
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("MyTheatre.Domain.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MyTheatre.Domain.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GenreId");

                    b.Property<string>("Plot");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("MyTheatre.Domain.Video", b =>
                {
                    b.HasOne("MyTheatre.Domain.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");
                });
        }
    }
}
