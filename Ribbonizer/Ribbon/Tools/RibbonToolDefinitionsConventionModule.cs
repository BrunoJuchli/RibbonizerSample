namespace Ribbonizer.Ribbon.Tools
{
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class RibbonToolDefinitionsConventionModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x
                .FromThisAssembly()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InheritedFrom<IRibbonToolDefinition>()
                .BindWith<RibbonBindingGenerator<IRibbonToolDefinition>>());
        }
    }
}