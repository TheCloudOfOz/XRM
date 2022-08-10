using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace XRM.Pre.Create
{
    public class Account : XrmPlugin
    {
        public Account()
        {
            this.EntityLogicalName = "account";
           
        }
        public override void Execute()
        {
            //string name = "";
            //if (Entity.Contains("name"))
            //{
            //    name = Entity.GetAttributeValue<string>("name");
            //}
            //else if (PreEntity.Contains("name"))
            //{
            //    name = PreEntity.GetAttributeValue<string>("name");
            //}
            //else
            //{
            //    name = "Unknown";
            //}

            string name = Entity.GetAttributeValue<string>(PreEntity, "name", "Unknown");
            int a = Entity.GetAttributeValue<int>(PreEntity, "number1", 0);
            int b = Entity.GetAttributeValue<int>(PreEntity, "number2", 0);

            //var query = new QueryByAttribute("contact");
            //query.ColumnSet = new ColumnSet(true);
            //query.Attributes.AddRange("ParentCustomerId");
            //query.Values.AddRange(Entity.Id);



            //var contacts = Service.RetrieveMultiple(query);
            //foreach (var contact in contacts.Entities)
            //{
            //    contact["number"] = contact.GetAttributeValue<int>("number") + 1;
            //    Service.Update(contact);
            //}


            var accountid = Entity.GetAttributeValue<Guid>("accountid",Guid.Empty);


            // Get LookUp Reference Value
            var user = Entity.GetAttributeValue<EntityReference>("createdby");

            //var u = Service.Retrieve(user.LogicalName, user.Id, new Microsoft.Xrm.Sdk.Query.ColumnSet("*"));
            // Instead of line above use this one from Extension Methods.
            var u = Service.Retrieve(user); // Returns Full Table Row
            u["city"] = "Sydney";
            Service.Update(u);

            base.Execute();
        }
    }
}
