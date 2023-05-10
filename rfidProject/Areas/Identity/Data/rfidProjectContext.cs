using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rfidProject.Models;

namespace rfidProject.Data;

public class rfidProjectContext : IdentityDbContext<AppUser>
{
    public rfidProjectContext(DbContextOptions<rfidProjectContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<CattleReg> CattleRegs { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Rfid> Rfids { get; set; }
    public DbSet<SlaughterCattle> SlaughterCattles { get; set; }
    public DbSet<SlaughterHouse> SlaughterHouses { get; set; }
}
