using Microsoft.Extensions.Configuration;

namespace TccBackendUmc.Utility.ConfigBuilders;

public abstract class ConfigSettings
{
    public IConfigurationRoot? Configuration { get; private set; }

    protected void LoadConfiguration(string file)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(file, optional: true, reloadOnChange: false);

        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (env != null && !string.IsNullOrWhiteSpace(env))
        {
            var idx = file.LastIndexOf(".json");
            var newFile = file.Insert(idx, $".{env}");

            builder = builder.AddJsonFile(newFile, optional: true, reloadOnChange: false);
        }

        Configuration = builder.Build();
    }

    public string? GetValue(string key)
    {
        return Configuration?[key];
    }
}
