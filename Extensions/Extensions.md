# Extension Methods for XRM Plugin

## Service Extensions

```csharp
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
        }
        
        public static Entity Retrieve(this IOrganizationService service, string entityName, Guid id, params string[] columns)
        {
            return service.Retrieve(entityName, id, columns != null && columns.Length > 0 ? new ColumnSet(columns) : new ColumnSet(true));
        }
```

#### Usage

##### Without using Extension Method

```csharp
        public void Execute(IServiceProvider serviceProvider)
        {
            this.Context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            this.Tracing = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            this.ServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
        }
```

##### Using Extension Method

```csharp
        public void Execute(IServiceProvider serviceProvider)
        {
            this.Context = serviceProvider.GetService<IPluginExecutionContext>();
            this.Tracing = serviceProvider.GetService<ITracingService>();
            this.ServiceFactory = serviceProvider.GetService<IOrganizationServiceFactory>();
        }
```