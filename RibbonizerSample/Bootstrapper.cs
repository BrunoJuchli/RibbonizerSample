namespace RibbonizerSample
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows;

    using Caliburn.Micro;

    using Ninject;

    using Ribbonizer.DependencyInjection;
    using Ribbonizer.Media;
    using Ribbonizer.Ribbon;
    using Ribbonizer.ViewModel.Lifecycle;
    using Ribbonizer.Wrappers.Microsoft;

    using RibbonizerSample.SampleTracking;

    public class Bootstrapper : BootstrapperBase
    {
        private readonly IKernel kernel;

        private ShellViewModel shellViewModel;

        public Bootstrapper()
        {
            this.kernel = new StandardKernel();
            this.Start();
        }

        protected override void Configure()
        {
            this.kernel.Load<DependencyInjectionModule>();
            this.kernel.Load<LifecycleModule>();
            this.kernel.Load<RibbonModule>();
            this.kernel.Load<MicrosoftRibbonWrappersModule>();
            this.kernel.Load<MediaModule>();
            this.kernel.Load<SampleTrackingModule>();
            
            this.kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();

            this.kernel.Get<IRibbonInitializer>().InitializeRibbonViewTree();

            base.Configure();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);

            this.shellViewModel = this.kernel.Get<ShellViewModel>();
            this.kernel.Get<IWindowManager>().ShowWindow(this.shellViewModel);
            this.kernel.Get<ILifecycleController>().Activate(this.shellViewModel);
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            this.kernel.Get<ILifecycleController>().Deactivate(this.shellViewModel);
            base.OnExit(sender, e);
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