using System;
using Microsoft.Practices.Unity;
using System.Web.Http;
using iCheap.Repositories;

namespace iCheap.Resolvers
{
    public class Resolvers
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            RegisterRepositories(container);

            config.DependencyResolver = new UnityResolver(container);
        }

        private static void RegisterRepositories(UnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
        }
    }
}
