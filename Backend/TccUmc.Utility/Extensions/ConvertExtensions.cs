using System.Diagnostics.CodeAnalysis;

namespace TccUmc.Utility.Extensions;

public static class ConvertExtensions
{
    [ExcludeFromCodeCoverage]
    public static T ConvertValue<T>(this string value)
    {
        return value.ConvertValue<string, T>();
    }

    private static TDest ConvertValue<TOrigin, TDest>(this TOrigin value)
    {
        try
        {
            return (TDest) Convert.ChangeType(value, typeof(TDest));
        }
        catch
        {
            return default;
        }
    }
}