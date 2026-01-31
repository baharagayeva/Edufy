using Edufy.Domain.Entities;
using Edufy.Domain.EntityConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Edufy.SqlServer.DbContext;

public class EdufyDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public EdufyDbContext(DbContextOptions<EdufyDbContext> options) : base(options)
    {
    } 
    
    public required DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}