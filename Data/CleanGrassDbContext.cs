using CleanGrassAppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanGrassAppWeb.Data;

public class CleanGrassDbContext : DbContext
{
    public DbSet<Servico> Servico { get; set; }
    public DbSet<Marca> Marca { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var stringConn = config.GetConnectionString("StringConnection");

        optionsBuilder.UseSqlite(stringConn);
    }
}


