using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SpyCheif.Application.BaseNosql;
using SpyCheif.Application.Feature.Command.AssetCommand.Add;
using SpyCheif.Application.Feature.Pipeline;
using SpyCheif.Application.Mapping;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Application.Validation.AssetValidation;
using SpyCheif.Persistance.EntityFramework.AssetRepo;
using SpyCheif.Persistance.EntityFramework.AssetTypeRepo;
using SpyCheif.Persistance.EntityFramework.ServiceDatabaseRepo;
using SpyCheif.Persistance.MongoDb.Base;
using SpyCheiif.Persistance.Context;

namespace SpyCheif.Persistence;

public static class Services
{

    public static IServiceCollection CreateSecretServices(this IServiceCollection service)
    {
        // DbContext
        service.AddDbContext<SpyChiefDbContext>(options => 
            options.UseMySql(Configuration.MysqlConnectionString,new MySqlServerVersion(Configuration.MysqlConnectionVersion)));


        //const string connectionUri = "mongodb+srv://emirahi45:38TOGmHk09mQr2qj@cluster0.3jbhx.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        const string connectionUri = "mongodb://mongoadmin:secret@localhost:27017/?retryWrites=true";

        MongoClient client = new MongoClient(connectionUri);
        service.AddSingleton<MongoClient>(client);


        // Read Repository
        service.AddScoped<IReadAssetRepository,EfCoreAssetReadRepository>();
        service.AddScoped<IReadAssetTypeRepository,EfCoreAssetTypeReadRepository>();
        service.AddScoped<IReadServiceDatabaseRepository,EfCoreServiceDatabaseReadRepository>();
        service.AddScoped<IBaseNoSqlReadRepository,MongoBaseReadRepository>();

        // Write Repository
        service.AddScoped<IWriteAssetRepository, EfCoreAssetWriteRepository>();
        service.AddScoped<IWriteAssetTypeRepository, EfCoreAssetTypeWriteRepository>();
        service.AddScoped<IWriteServiceDatabaseRepository, EfCoreServiceDatabaseWriteRepository>();

        //service.AddTransient(typeof(IPipelineBehavior<,>), typeof(PreValidationPipeline<,>));

        // Other Service

        service.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(AssetAddCommentHandler).Assembly);
            cfg.AddOpenBehavior(typeof(PreValidationPipeline<,>));
        });
        service.AddAutoMapper(typeof(AssetMapping));
        service.AddValidatorsFromAssemblyContaining<AddAssetValidate>();

        return service;
    }
    
}