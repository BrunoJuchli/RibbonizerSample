namespace Ribbonizer.Ribbon
{
    using Ninject.Modules;

    public class RibbonModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRibbonProvider, IRibbonProviderInitialization>().To<RibbonProvider>()
                .InSingletonScope();

            this.Bind<IRibbonInitializer>().To<RibbonInitializer>();

            this.Bind(typeof(IGroupedDefinitionProvider<>)).To(typeof(GroupedDefinitionProvider<>));
        }
    }
}