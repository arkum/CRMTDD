using Microsoft.Xrm.Sdk;
using System;
using Xunit;

namespace CRMPlugin
{
    public class ContactBirthdayunittests
    {
        [Fact]
        public void Plugin_should_fire_onlyon_precreate()
        {
            ContactBirthdayPlugin plugin = new ContactBirthdayPlugin();
            FakeServiceProvider serviceProvider = new FakeServiceProvider();
            plugin.Execute(serviceProvider);
        }
        [Fact]
        public void Plugin_should_throw_exception_ifinvoked_for_a_different_message()
        {
            ContactBirthdayPlugin plugin = new ContactBirthdayPlugin();
            FakeServiceProvider serviceProvider = new FakeServiceProvider(new FakePluginExecutionContext("Update"));
            Exception ex = Assert.Throws< InvalidPluginExecutionException>(()=> plugin.Execute(serviceProvider));
            Assert.Equal("Plugin is registered for PreCreate but executed for Update", ex.Message);

        }
        [Fact]
        public void PluginExecutionContext_should_contain_preimage()
        {
            ContactBirthdayPlugin plugin = new ContactBirthdayPlugin();
            FakeServiceProvider serviceProvider = new FakeServiceProvider(new FakePluginExecutionContext("PreCreate"));
            plugin.Execute(serviceProvider);

        }
        [Fact]
        public void PreImage_should_be_contact_entity()
        {
            ContactBirthdayPlugin plugin = new ContactBirthdayPlugin();
            FakeServiceProvider serviceProvider = new FakeServiceProvider(new FakePluginExecutionContext("PreCreate"));
            plugin.Execute(serviceProvider);

        }
        [Fact]
        public void PreImage_should_contain_birthdate()
        {
            ContactBirthdayPlugin plugin = new ContactBirthdayPlugin();
            FakeServiceProvider serviceProvider = new FakeServiceProvider(new FakePluginExecutionContext("PreCreate"));
            plugin.Execute(serviceProvider);
        }
        [Fact]
        public void BirthDate_should_be_less_than_today()
        {
            ContactBirthdayPlugin plugin = new ContactBirthdayPlugin();
            var preImage = new Entity("Contact");
            preImage.Attributes["birthdate"] = DateTime.Now.AddYears(-20);
            FakeServiceProvider serviceProvider = new FakeServiceProvider(new FakePluginExecutionContext("PreCreate", preImage));
            plugin.Execute(serviceProvider);
        }
        [Fact]
        public void Plugin_should_throw_exception_if_birthdate_is_greater_than_today()
        {
            ContactBirthdayPlugin plugin = new ContactBirthdayPlugin();
            var preImage = new Entity("contact");
            preImage.Attributes["birthdate"] = DateTime.Now.AddYears(1);
            FakeServiceProvider serviceProvider = new FakeServiceProvider(new FakePluginExecutionContext("PreCreate", preImage));
            var ex = Assert.Throws<InvalidPluginExecutionException>(()=> plugin.Execute(serviceProvider));
            Assert.Equal("BirthDate cannot be greater than today.", ex.Message);

        }
    }
}
