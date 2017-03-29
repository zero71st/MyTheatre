using System.Collections.Generic;
using MyTheatre.Domain;
using Microsoft.EntityFrameworkCore;
namespace MyTheatre.Api.Infrastructure
{
    public class MyTheatreContext:DbContext
    {
        public MyTheatreContext(DbContextOptions<MyTheatreContext> options):base(options)
        {
            
        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}