using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace Mastery.Example.MVC
{
    public class NinjectResolverMvc : IDependencyResolver
    {
        private IKernel Kernel { get; }

        public NinjectResolverMvc(IKernel kernel) 
            => Kernel = kernel;

        public object GetService(Type serviceType) 
            => Kernel.TryGet(serviceType);

        public IEnumerable<object> GetServices(Type serviceType) 
            => Kernel.GetAll(serviceType);
    }
}