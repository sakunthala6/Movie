using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureProject
{
    public class ShowContext : DbContext
    {
        public ShowContext(DbContextOptions<ShowContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Movie>().HasData(
                    new Movie
                    {
                        Id = 1,
                        Name = "Sherlock Holmes",

                        Description = "Mystery",

                        Duration = 2f,

                    });
        }
    }
}
