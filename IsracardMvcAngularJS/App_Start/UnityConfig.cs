using IsracardMvcAngularJS.Core;
using IsracardMvcAngularJS.Core.interfaces;
using IsracardMvcAngularJS.Core.models;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace IsracardMvcAngularJS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IDataStorageService<List<Repository>>, SessionDataStorageService<List<Repository>>>();
            container.RegisterType<IRepositoryService, RepositoryService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}