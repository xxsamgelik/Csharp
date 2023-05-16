using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MvcApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
