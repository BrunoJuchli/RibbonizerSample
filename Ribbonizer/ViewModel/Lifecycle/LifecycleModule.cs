namespace Ribbonizer.ViewModel.Lifecycle
{
    using Ninject.Extensions.Factory;
    using Ninject.Modules;

    public class LifecycleModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ILifecycleController>().To<LifecycleController>().InSingletonScope();

            this.Bind<ILifecycleManagerFactory>().ToFactory();
            this.Bind<ILifecycleManager>().To<LifecycleManager>();

            this.Bind<ILifecycleExtensionTypeCache>().To<LifecycleExtensionTypeCache>().InSingletonScope();
            this.Bind<ILifecycleExtensionBuilder>().To<LifecycleExtensionBuilder>();
            this.Bind<ILifecycleExtensionFactory>().To<LifecycleExtensionFactory>();
        }
    }
}