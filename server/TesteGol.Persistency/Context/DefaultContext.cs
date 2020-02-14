using Microsoft.EntityFrameworkCore;
using System;
using TesteGol.Model.Entities;

namespace TesteGol.Persistency.Context
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Login = "admin",
                    Password = "admin",
                    FirstName = "Administrador",
                    LastName = "do Sistema",
                    Id = new Guid("ca7078b8-9dda-40a4-9233-b6ce61e6d940")
                }

            );
        }

    }
}
