using Microsoft.EntityFrameworkCore;

namespace TechcareerWebApiTutorial.Models.ORM
{
    public class TechCareerDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConnectionString

            optionsBuilder.UseSqlServer("server=Kadir\\SQLEXPRESS;initial catalog=TechCareerDb;integrated security=true ;TrustServerCertificate=true");
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
