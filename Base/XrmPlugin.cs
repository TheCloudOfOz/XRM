using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xrm.Sdk;

namespace XRM
{
    public abstract class XrmPlugin : IPlugin
    {
        public XrmPlugin() { }
        public XrmPlugin(string unsecure)
        {
            this.Unsecure = unsecure;
        }
        public XrmPlugin(string unsecure, string secure)
        {
            this.Unsecure = unsecure;
            this.Secure = secure;
        }

        public string Secure { get; private set; }
        public string Unsecure { get; private set; }
        public string PluginName { get; set; }
        public string EntityLogicalName { get; set; }
        public Entity Entity { get; private set; }
        public Entity PreEntity { get; private set; }
        public Entity PostEntity { get; private set; }
        public string PreImageName { get; set; }
        public string PostImageName { get; set; }
        public ITracingService Tracing { get; private set; }
        public IPluginExecutionContext Context { get; private set; }
        public IOrganizationServiceFactory ServiceFactory { get; private set; }
        public IOrganizationService Service { get; private set; }
        public void Execute(IServiceProvider serviceProvider)
        {
            this.Context = serviceProvider.GetService<IPluginExecutionContext>();

            if (this.Context.InputParameters.Contains("Target") && this.Context.InputParameters["Target"] is Entity)
            {
                this.Entity = this.Context.InputParameters["Target"] as Entity;
                if (this.Entity.LogicalName != this.EntityLogicalName)
                {
                    return;
                }

                this.Tracing = serviceProvider.GetService<ITracingService>();
                this.ServiceFactory = serviceProvider.GetService<IOrganizationServiceFactory>();
                this.Service = this.ServiceFactory.CreateOrganizationService(this.Context.UserId);

                if (!String.IsNullOrEmpty(this.PreImageName) && this.Context.PreEntityImages.Contains(this.PreImageName) && this.Context.PreEntityImages[this.PreImageName] is Entity)
                {
                    this.PreEntity = this.Context.PreEntityImages[this.PreImageName] as Entity;
                }
                if (!String.IsNullOrEmpty(this.PostImageName) && this.Context.PostEntityImages.Contains(this.PostImageName) && this.Context.PostEntityImages[this.PostImageName] is Entity)
                {
                    this.PostEntity = this.Context.PostEntityImages[this.PostImageName] as Entity;
                }

                try
                {
                    this.Execute();
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException(String.Format("An error occurred in {0} Exception:{1}", this.PluginName, ex.ToString()));
                }
                catch (Exception ex)
                {
                    Tracing.Trace("Plugin Name : {0} Exception : {1}", this.PluginName, ex.ToString());
                    throw;
                }
            }
        }
        public virtual void Execute() { }
    }
}