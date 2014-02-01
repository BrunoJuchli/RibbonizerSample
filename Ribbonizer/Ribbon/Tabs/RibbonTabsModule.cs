namespace Ribbonizer.Ribbon.Tabs
{
    using Ninject.Modules;

    using Ribbonizer.Ribbon.DefinitionValidation;
    using Ribbonizer.Ribbon.Groups;

    public class RibbonTabsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRibbonTabController>().To<RibbonTabController>()
                .InSingletonScope();

            this.Bind<IRibbonTabViewCache, IRibbonTabViewCacheInitializer>().To<RibbonTabViewCache>()
                .InSingletonScope();

            this.Bind<IRibbonViewBuilder<IRibbonTabDefinition, IRibbonTabView>>()
                .To<RibbonViewWithChildrenBuilder<IRibbonTabDefinition, IRibbonTabView, IRibbonGroupView>>();

            this.Bind<IRibbonViewFactory<IRibbonTabDefinition, IRibbonTabView, IRibbonGroupView>>().To<RibbonTabFactory>();

            this.BindValidators();
        }

        private void BindValidators()
        {
            this.Bind<IRibbonDefinitionValidator>().To<RibbonTabDefinitionShowOnActivationOfViewModelTypeValidator<IRibbonTabDefinition>>();
        }
    }
}