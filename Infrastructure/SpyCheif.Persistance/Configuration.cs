using Microsoft.Extensions.Configuration;

namespace SpyCheif.Persistence;

public static class Configuration
{
    public static string? MysqlConnectionString {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/"));
            configurationManager.AddJsonFile("appsettings.json");
            
            string? result = configurationManager["ConnectionString:Mysql"];
            return result;
        }
    }
    public static string? MysqlConnectionVersion {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager["ConnectionString:MysqlVersion"];
        }
    }
}