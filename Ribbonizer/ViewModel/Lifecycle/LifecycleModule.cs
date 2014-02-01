namespace Ribbonizer.ViewModel.Lifecycle
{
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Factory;
    using Ninject.Modules;

    using Ribbonizer.DependencyInjection;

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

            this.BindLifecycleExtensionProviders();
        }

        private void BindLifecycleExtensionProviders()
        {
            this.Bind(x => x
                        .FromProductionAssemblies()
                        .IncludingNonePublicTypes()
                        .SelectAllClasses()
                        .InheritedFrom<ILifecycleExtensionProvider>()
                        .BindTo<ILifecycleExtensionProvider>());
        }
    }
}