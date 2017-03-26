using Microsoft.Xrm.Sdk;
using System;

namespace CRMPlugin
{
    public class FakeServiceProvider : IServiceProvider
    {
        private IPluginExecutionContext _executionContext;

        public FakeServiceProvider()
        {
            _executionContext = new FakePluginExecutionContext("PreCreate");
        }
        public FakeServiceProvider(IPluginExecutionContext context)
        {
            _executionContext = context;
        }
        public object GetService(Type serviceType)
        {
            return _executionContext;
        }
    }
}