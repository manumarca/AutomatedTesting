using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.cs.Interfaces;
using ModelsLibrary.Shared;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Repositories.cs
{
    public class UnitOfWork
    {
        UnityContainer container = new UnityContainer();
        private IRepository<Resource> resourceRepository;
        private IRepository<GlobalSettings> globalSettingsRepository;
        private IRepository<LawFirmFeed> lawFirmFeedRepository;
        private IRepository<AccountantFirmFeed> accountFirmFeedRepository;
        private IRepository<TopicFeed> topicFeedRepository;
        public UnitOfWork()
        {
            container.LoadConfiguration();
        }

        public IRepository<TopicFeed> TopicFeed
        {
            get
            {
                if (this.topicFeedRepository == null)
                {
                    this.topicFeedRepository = container.Resolve<IRepository<TopicFeed>>();
                }
                return topicFeedRepository;
            }
        }

        public IRepository<AccountantFirmFeed> AccountantFirmFeed
        {
            get
            {
                if (this.accountFirmFeedRepository == null)
                {
                    this.accountFirmFeedRepository = container.Resolve<IRepository<AccountantFirmFeed>>();
                }
                return accountFirmFeedRepository;
            }
        }

        public IRepository<Resource> ResourceRepository
        {
            get
            {
                if(this.resourceRepository == null)
                {
                    this.resourceRepository = container.Resolve<IRepository<Resource>>();
                }
                return resourceRepository;
            }
        }

        public IRepository<GlobalSettings> EnvironmentRepository
        {
            get
            {
                if (this.globalSettingsRepository == null)
                {
                    this.globalSettingsRepository = container.Resolve<IRepository<GlobalSettings>>();
                }
                return globalSettingsRepository;
            }
        }
        public IRepository<LawFirmFeed> LawFirmFeed
        {
            get
            {
                if (this.lawFirmFeedRepository == null)
                {
                    this.lawFirmFeedRepository = container.Resolve<IRepository<LawFirmFeed>>();
                }
                return lawFirmFeedRepository;
            }
        }
    }
}
