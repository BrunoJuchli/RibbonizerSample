namespace Ribbonizer.Ribbon.Tools
{
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.NamedScope;
    using Ninject.Modules;

    using Ribbonizer.DependencyInjection;
    using Ribbonizer.Ribbon.DefinitionValidation;
    using Ribbonizer.Ribbon.Groups;

    public class RibbonToolsModule : NinjectModule
    {
        public const string RibbonToolInstanceScope = "RibbonToolInstanceScope";

        public override void Load()
        {
            this.Bind<IRibbonToolControllerCache>().To<RibbonToolControllerCache>().InSingletonScope();

            this.Bind<IRibbonViewBuilder<IRibbonToolDefinition, object>>().To<RibbonToolBuilder>();

            this.Bind(typeof(IRibbonToolFactory<>)).To(typeof(RibbonToolFactory<>))
                .DefinesNamedScope(RibbonToolInstanceScope);

            this.Bind(typeof(IRibbonToolControllerFactory<>)).To(typeof(RibbonToolControllerFactory<>));

            this.Bind<IRibbonToolWiringFactory>().To<RibbonToolWiringFactory>();

            this.Bind<IRibbonChildrenViewBuilder<object>>().To<RibbonChildrenViewBuilder<IRibbonToolDefinition, object>>();

            this.BindDefinitionValidators();
            this.BindDefinitions();
        }

        private void BindDefinitionValidators()
        {
            this.Bind<IRibbonDefinitionValidator>().To<RibbonDefinitionWireOnActivationOfViewModelTypeValidator<IRibbonToolDefinition>>();
            this.Bind<IRibbonDefinitionValidator>().To<RibbonDefinitionParentTypeValidator<IRibbonToolDefinition, IRibbonGroupDefinition>>();
            this.Bind<IRibbonDefinitionValidator>().To<RibbonDefinitionSortIndexValidator<IRibbonToolDefinition>>();
        }

        private void BindDefinitions()
        {
            this.Bind(x => x
                .FromProductionAssemblies()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InheritedFrom<IRibbonToolDefinition>()
                .BindWith<RibbonBindingGenerator<IRibbonToolDefinition>>());
        }
    }
}