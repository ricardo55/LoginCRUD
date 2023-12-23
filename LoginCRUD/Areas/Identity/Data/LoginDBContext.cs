using LoginCRUD.Areas.Identity.Data;
using LoginCRUD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoginCRUD.Data;

public class LoginDBContext : IdentityDbContext<ApplicationUser>
{
    public LoginDBContext(DbContextOptions<LoginDBContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
     public DbSet<LoginCRUD.Models.Movie> Movie { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

           // modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
            builder.Entity<Movie>().ToTable("Movie");


        
        
    }
}
