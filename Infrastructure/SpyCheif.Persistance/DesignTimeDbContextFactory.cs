using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistence;

public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<SpyChiefDbContext>
{

    public DesignTimeDbContextFactory()
    {
    }
    
    public SpyChiefDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SpyChiefDbContext> contextOptionsBuilder = new();
        contextOptionsBuilder.UseMySql(Configuration.MysqlConnectionString,
            new MySqlServerVersion(Configuration.MysqlConnectionVersion));

        return new(contextOptionsBuilder.Options);
    }
    
   
}