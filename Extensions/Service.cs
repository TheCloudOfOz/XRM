using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace XRM
{
    public static class ServiceExtensions
    {
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
        }
        public static Entity Retrieve(this IOrganizationService service, string entityName, Guid id, params string[] columns)
        {
            return service.Retrieve(entityName, id, columns != null && columns.Length > 0 ? new ColumnSet(columns) : new ColumnSet(true));
        }
        public static Entity Retrieve(this IOrganizationService service, EntityReference entityReference, params string[] columns)
        {
            return service.Retrieve(entityReference.LogicalName, entityReference.Id, columns);
        }
    }
}