﻿using Microsoft.EntityFrameworkCore;

namespace TechcareerWebApiTutorial.Models.ORM
{
    public class TechCareerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConnectionString

            optionsBuilder.UseSqlServer("server=Kadir\\SQLEXPRESS;initial catalog=TechCareerDb;integrated security=true ;TrustServerCertificate=true");
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UsersForToken> UsersForTokens { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
