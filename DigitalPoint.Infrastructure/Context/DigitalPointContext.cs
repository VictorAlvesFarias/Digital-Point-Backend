using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DigitalPoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalPoint.Infra.Context;

public class DigitalPointContext : IdentityDbContext
{
    public DigitalPointContext(DbContextOptions options) : base(options){}
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<WorkPoint> WorkPoints { get; set; }

}