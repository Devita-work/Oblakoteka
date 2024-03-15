using Microsoft.EntityFrameworkCore;
using Oblakoteka.Models;

namespace Oblakoteka;
public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }
}