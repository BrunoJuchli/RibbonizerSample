namespace Ribbonizer.Ribbon.Tabs
{
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    using Ribbonizer.DependencyInjection;
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
            this.BindTabDefinitions();
        }

        private void BindValidators()
        {
            this.Bind<IRibbonDefinitionValidator>().To<RibbonTabDefinitionShowOnActivationOfViewModelTypeValidator<IRibbonTabDefinition>>();
        }

        private void BindTabDefinitions()
        {
            this.Bind(x => x
                               .FromProductionAssemblies()
                               .IncludingNonePublicTypes()
                               .SelectAllClasses()
                               .InheritedFrom<IRibbonTabDefinition>()
                               .BindWith<RibbonBindingGenerator<IRibbonTabDefinition>>());
        }
    }
}