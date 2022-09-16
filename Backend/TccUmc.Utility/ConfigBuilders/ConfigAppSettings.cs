using System.Diagnostics.CodeAnalysis;

namespace TccUmc.Utility.ConfigBuilders;

[ExcludeFromCodeCoverage]
public sealed class ConfigAppSettings : ConfigSettings
{
    private static ConfigAppSettings _instance;
    private static readonly object Padlock = new();

    private ConfigAppSettings()
    {
        LoadConfiguration("appsettings.json");
    }

    public static ConfigAppSettings Instance
    {
        get
        {
            if (_instance != null) return _instance;
            lock (Padlock)
            {
                _instance ??= new ConfigAppSettings();
            }

            return _instance;
        }
    }
}