# XRM

Microsoft Dynamics 365 Plugin

## Extensions

### Service Extensions

```csharp
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
        }
```

#### Usage

```csharp
        public void Execute(IServiceProvider serviceProvider)
        {
            this.Context = serviceProvider.GetService<IPluginExecutionContext>();
            this.Tracing = serviceProvider.GetService<ITracingService>();
            this.ServiceFactory = serviceProvider.GetService<IOrganizationServiceFactory>();
        }
```
