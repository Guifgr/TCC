﻿using Microsoft.Extensions.Configuration;
using TccUmc.Utility.ConfigBuilders;

namespace TccUmc.Utility.Extensions
{
    public static class EnvironmentVariableExtension
    {
        public static T GetEnvironmentVariable<T>(string environmentKey, string configFileKey, IConfigurationRoot configuration = null)
        {
            string value = null;

            if (configuration == null)
                configuration = ConfigAppSettings.Instance.Configuration;

            if (!string.IsNullOrEmpty(environmentKey))
            {
                value = Environment.GetEnvironmentVariable(environmentKey);
            }
            if (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(configFileKey))
            {
                value = configuration[configFileKey];
            }
            return value.ConvertValue<T>();
        }
    }
}