using database.Models;
using System.Data.Entity;

public class MobileContext : DbContext
{
    public MobileContext() : base("DefaultConnection")
    {

    }
    public DbSet<Disciplines> Disciplines { get; set; }
}
