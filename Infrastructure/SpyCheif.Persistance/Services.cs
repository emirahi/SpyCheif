
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistence;

public static class Services
{

    public static IServiceCollection CreateSecretServices(this IServiceCollection service)
    {
        // DbContext
        service.AddDbContext<SpyChiefDbContext>(options => 
            options.UseMySql(Configuration.MysqlConnectionString,new MySqlServerVersion(Configuration.MysqlConnectionVersion)));
        
        // Read Repository

        //service.AddScoped<IEfCoreReadCategoryRepository,EfCoreReadCategoryRepository>();
        
        // Write Repository
        
        //service.AddScoped<IEfCoreWriteCategoryRepository,EfCoreWriteCategoryRepository>();
        // AutoMapper
        
        //service.AddAutoMapper(typeof(CategoryMapProfile));
        
        return service;
    }
    
}