using EntityFramework.Exceptions.PostgreSQL;
using LeftOverLove.Common.Dtos;
using LeftOverLove.Common.Entities;
using LeftOverLove.Common.Settings;
using LeftOverLove.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LeftOverLove.DataAccess;

public class AppDbContext : DbContext
{
    private readonly IOptions<AppSettings> _options;

    public AppDbContext(IOptions<AppSettings> options)
    {
        _options = options;
    }

    public DbSet<Item> Items { get; private set; } = null!;
    public DbSet<Customer> Customers { get; private set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseExceptionProcessor();
        optionsBuilder.UseNpgsql(_options.Value.ConnectionString);
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}
