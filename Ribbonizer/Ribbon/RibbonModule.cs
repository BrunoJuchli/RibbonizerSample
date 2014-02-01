namespace Ribbonizer.Ribbon
{
    using Ninject;
    using Ninject.Modules;

    using Ribbonizer.Ribbon.Groups;
    using Ribbonizer.Ribbon.Tabs;
    using Ribbonizer.Ribbon.Tools;
    using Ribbonizer.Ribbon.Wrapping;

    public class RibbonModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRibbonProvider, IRibbonProviderInitialization>().To<RibbonProvider>()
                .InSingletonScope();

            this.Bind<IRibbonInitializer>().To<RibbonInitializer>();

            this.Bind(typeof(IGroupedDefinitionProvider<>)).To(typeof(GroupedDefinitionProvider<>));

            this.Kernel.Load<RibbonTabsModule>();
            this.Kernel.Load<RibbonGroupsModule>();
            this.Kernel.Load<RibbonToolsModule>();
            this.Kernel.Load<RibbonViewWrappingModule>();
        }
    }
}