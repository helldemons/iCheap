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

        public static void Register(IUnityContainer container)
        {
            RegisterRepositories(container);
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IOriginRepository, OriginRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBrandRepository, BrandRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IBlogCategoryRepository, BlogCategoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBlogRepository, BlogRepository>(new HierarchicalLifetimeManager());
        }
    }
}
