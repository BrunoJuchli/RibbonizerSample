namespace Ribbonizer.Ribbon.Tabs
{
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class RibbonTabsDefinitionsConventionModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x
                            .FromThisAssembly()
                            .IncludingNonePublicTypes()
                            .SelectAllClasses()
                            .InheritedFrom<IRibbonTabDefinition>()
                            .BindWith<RibbonBindingGenerator<IRibbonTabDefinition>>());
        }
    }
}