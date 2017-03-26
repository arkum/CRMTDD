using System;
using Microsoft.Xrm.Sdk;

namespace CRMPlugin
{
    internal class FakePluginExecutionContext : IPluginExecutionContext
    {
        private string _messageName;
        private EntityImageCollection _preImages = new EntityImageCollection();
        
        public FakePluginExecutionContext()
        {
            _preImages.Add("PreImage", new Entity("contact"));
        }

        public FakePluginExecutionContext(string messageName):this()
        {
            this._messageName = messageName;
        }

        public FakePluginExecutionContext(string messageName, Entity preImage)
        {
            _messageName = messageName;
            _preImages.Add("PreImage", preImage);
        }
        public Guid BusinessUnitId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid CorrelationId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Depth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid InitiatingUserId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ParameterCollection InputParameters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsExecutingOffline
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsInTransaction
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsOfflinePlayback
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int IsolationMode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string MessageName
        {
            get
            {
                return _messageName;
            }
        }

        public int Mode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTime OperationCreatedOn
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid OperationId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid OrganizationId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string OrganizationName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ParameterCollection OutputParameters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EntityReference OwningExtension
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IPluginExecutionContext ParentContext
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EntityImageCollection PostEntityImages
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EntityImageCollection PreEntityImages
        {
            get
            {
                return _preImages;
            }
        }

        public Guid PrimaryEntityId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string PrimaryEntityName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid? RequestId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string SecondaryEntityName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ParameterCollection SharedVariables
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Stage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid UserId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}