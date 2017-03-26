using System;
using Microsoft.Xrm.Sdk;

namespace CRMPlugin
{
    public class ContactBirthdayPlugin : IPlugin
    {
        public string MessageName { get; private set; }

        public ContactBirthdayPlugin()
        {
            MessageName = "PreCreate";
        }
        public ContactBirthdayPlugin(string message)
        {
            MessageName = message;
        }
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = serviceProvider.GetService(typeof(IPluginExecutionContext)) as IPluginExecutionContext;
            if (context.MessageName != this.MessageName)
                throw new 
                    InvalidPluginExecutionException($"Plugin is registered for {MessageName} but executed for {context.MessageName}");
            Entity preImage = context.PreEntityImages["PreImage"] as Entity;
            if (!preImage.LogicalName.Equals("contact")) return;
            if (!preImage.Contains("birthdate")) return;
            DateTime birthDate = (DateTime)preImage["birthdate"];
            if (birthDate > DateTime.Now)
                throw new InvalidPluginExecutionException("BirthDate cannot be greater than today.");

        }
    }
}