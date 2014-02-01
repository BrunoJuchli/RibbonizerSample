﻿namespace RibbonizerSample
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Caliburn.Micro;

    using Ninject;

    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        private IKernel kernel;
        
        protected override void Configure()
        {
            this.kernel = new StandardKernel();
            this.kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();

            base.Configure();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return this.kernel.GetAll(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrEmpty(key) ? this.kernel.Get(service) : this.kernel.Get(service, key);
        }

        protected override void BuildUp(object instance)
        {
            this.kernel.Inject(instance);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] { Assembly.GetEntryAssembly() };
        }
    }
}