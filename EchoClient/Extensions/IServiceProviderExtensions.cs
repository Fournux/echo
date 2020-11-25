using System;

public static class IServiceProviderExtensions
{
    public static T Get<T>(this IServiceProvider provider)
    {
        return (T)provider.GetService(typeof(T));
    }
}