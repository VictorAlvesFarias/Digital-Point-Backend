using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DigitalPoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DigitalPoint.Infra.Context;

public class DigitalPointContext : IdentityDbContext
{
    public DigitalPointContext(DbContextOptions options) : base(options){}
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<WorkPoint> WorkPoints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(e => e.WorkPoint)
            .WithOne(e => e.ApplicationUser)
            .HasForeignKey(e => e.ApplicationUserId)
            .IsRequired();
    }

}