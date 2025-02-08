using Microsoft.EntityFrameworkCore;
using web_api.Model;

namespace web_api.Data
{
   public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Product_Id);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Product_Name)
            .IsRequired();
    }
}
}