using FootballApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FootballPlayer>().HasData(
            new FootballPlayer
            {
                Id = 1,
                Name = "Dave Rogers",
                Team = "Rushie United",
                Nationality = "Scottish",
                Age = 23
            },
            new FootballPlayer
            {
                Id = 2,
                Name = "Jimmy Fred",
                Team = "Astro Rovers",
                Nationality = "French",
                Age = 30
            },
            new FootballPlayer
            {
                Id = 3,
                Name = "Roy Kollow",
                Team = "Red Warriors",
                Nationality = "Danish",
                Age = 27
            });

            modelBuilder.Entity<FootballTeam>().HasData(
            new FootballTeam
            {
               Id = 1,
               Name = "Yuko warriors",
               YearFounded = 1945,
               Country = "France",
               Manager = "Mr T"
            },
            new FootballTeam
            {
                Id = 2,
                Name = "Green Lamp United",
                YearFounded = 1890,
                Country = "England",
                Manager = "Mr Q"
            },
            new FootballTeam
            {
                Id = 3,
                Name = "Red Sea United",
                YearFounded = 1956,
                Country = "Brazil",
                Manager = "Mr Z"
            });
        }


        public DbSet<FootballPlayer> players { get; set; }
        public DbSet<FootballTeam> teams { get; set; }
        
    }
}
