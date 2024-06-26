using InfinionAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace InfinionAPI.Data
{
    public class InfinionDbContext : IdentityDbContext<IdentityUser>
    {
        DbSet<Users> User { get; set; }
        public InfinionDbContext(DbContextOptions<InfinionDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            seedRoles(modelBuilder);
            SeedUsers(modelBuilder);



        }


        private static void seedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(new
                IdentityRole() { Name = "InfinionAdmin", ConcurrencyStamp = "1", NormalizedName = "InfinionAdmin" },
              new  IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User"}
         );
        }

        private void SeedUsers(ModelBuilder modelBuilder) {

            var users = new List<Users>()
            {
                new Users()
                {
                    Id = 1,
                    FirstName = "Babatunde",
                    LastName = "Mustapha",
                    EmailAddress = "Fawazboluwatife@gmail.com",
                    Password="123456789a"

                },
                new Users()
                {
                    Id = 2,
                    FirstName = "Yemi",
                    LastName = "Kosoko",
                    EmailAddress = "boluwatifeYemi@gmail.com",
                    Password="123456789a"
                }


            };

            modelBuilder.Entity<Users>().HasData(users);
        }
    }
}
