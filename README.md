# XRM

Microsoft Dynamics 365 Plugin

## Extension Methods

### Service Extension Methods

```csharp
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
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
