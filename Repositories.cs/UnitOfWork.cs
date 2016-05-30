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
        private IRepository<RSSFeed> rssFeedRepository;
        
        public UnitOfWork()
        {
            container.LoadConfiguration();
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
        public IRepository<RSSFeed> RssFeedRepository
        {
            get
            {
                if (this.rssFeedRepository == null)
                {
                    this.rssFeedRepository = container.Resolve<IRepository<RSSFeed>>();
                }
                return rssFeedRepository;
            }
        }
    }
}
