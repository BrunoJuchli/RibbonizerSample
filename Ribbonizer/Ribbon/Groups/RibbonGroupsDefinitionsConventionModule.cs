namespace Ribbonizer.Ribbon.Groups
{
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    public class RibbonGroupsDefinitionsConventionModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x
                            .FromThisAssembly()
                            .IncludingNonePublicTypes()
                            .SelectAllClasses()
                            .InheritedFrom<IRibbonGroupDefinition>()
                            .BindWith<RibbonBindingGenerator<IRibbonGroupDefinition>>());
        }
    }
}