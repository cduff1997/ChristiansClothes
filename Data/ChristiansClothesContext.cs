#nullable disable

using ChristiansClothes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChristiansClothes.Data;

public class ChristiansClothesContext : DbContext
{
    public ChristiansClothesContext(DbContextOptions<ChristiansClothesContext> options) : base(options) { }

    public DbSet<ChristiansClothes.Models.ProductModel> ProductDb { get; set; }
    public DbSet<ContactModel> ContactDb { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChristiansClothes.Models.ProductModel>().HasKey(e => e.ProductId);
        modelBuilder.Entity<ContactModel>().HasKey(e => e.ContactId);

        base.OnModelCreating(modelBuilder);
    }
}

#nullable restore