namespace Ribbonizer.ViewModel.Lifecycle
{
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    using Ribbonizer.DependencyInjection;

    public class LifecycleExtensionsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x
                .FromThisAssembly()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InheritedFrom<ILifecycleExtensionProvider>()
                .BindTo<ILifecycleExtensionProvider>());
        }
    }
}