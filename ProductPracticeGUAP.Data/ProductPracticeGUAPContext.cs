using Microsoft.EntityFrameworkCore;
using ProductPracticeGUAP.Data.Entities;

namespace ProductPracticeGUAP.Data;

public class ProductPracticeGUAPContext : DbContext
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Dog> Dogs { get; set; }

    public ProductPracticeGUAPContext(DbContextOptions<ProductPracticeGUAPContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dog>(entity =>
        {
            entity.ToTable(nameof(Dog));
            entity.HasKey(e => e.Id);

            entity
                .HasOne(od => od.Owner)
                .WithMany(o => o.Dogs);
        });

/*        modelBuilder.Entity<Owner>(entity =>
        {
            entity.ToTable(nameof(Owner));
            entity.HasKey(e => e.Id);
        });*/
    }
}