using Microsoft.Xrm.Sdk;
using System;

namespace XRM
{
    public static class ServiceExtensions
    {
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}