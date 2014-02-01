namespace Ribbonizer.Ribbon.Tools.Button
{
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.NamedScope;
    using Ninject.Modules;

    using Ribbonizer.Ribbon.DefinitionValidation;

    public class RibbonButtonToolModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRibbonToolViewInitializer<IRibbonButtonToolDefinition>>().To<RibbonButtonToolViewInitializer>();
            this.Bind<IRibbonToolController<IRibbonButtonToolDefinition>>().To<RibbonButtonToolController>();

            this.Bind<IRibbonButtonToolCommandAdapter>().To<RibbonButtonToolCommandAdapter>()
                .InNamedScope(RibbonToolsModule.RibbonToolInstanceScope);

            this.Bind<IRibbonDefinitionValidator>().To<RibbonButtonDefinitionWireOnActivationOfViewModelTypeValidator>();

            this.BindCommands();
        }

        private void BindCommands()
        {
            this.Bind(x => x
                .FromThisAssembly()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InheritedFrom<IRibbonButtonToolCommand>()
                .BindToSelf()
                .Configure(syntax => syntax
                    .OnActivation(command => command.ExecuteIfInstanceIsOfType<IInitializableRibbonButtonToolCommand>(c => c.Initialize()))));
        }
    }
}