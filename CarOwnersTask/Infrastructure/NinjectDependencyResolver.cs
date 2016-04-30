using System;
using System.Collections.Generic;
using Ninject;
using System.Web.Mvc;
using CarOwnersTask.Repository.Interfaces;
using CarOwnersTask.Repository.Concrete;

namespace CarOwnersTask.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICarRepository>().To<CarRepository>();
            kernel.Bind<ICarTypeRepository>().To<CarTypeRepository>();
            kernel.Bind<IOwnerRepository>().To<OwnerRepository>();
            kernel.Bind<ICarOwnerRepository>().To<CarOwnerRepository>();
        }
    }
}