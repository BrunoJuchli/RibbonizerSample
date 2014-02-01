namespace Ribbonizer.Ribbon.Tools
{
    using Ninject;
    using Ninject.Syntax;

    using Ribbonizer.DependencyInjection;

    internal class RibbonToolControllerFactory<TDefinition> : IRibbonToolControllerFactory<TDefinition>
        where TDefinition : class, IRibbonToolDefinition
    {
        private readonly IResolutionRoot resolutionRoot;

        public RibbonToolControllerFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public IRibbonToolController<TDefinition> Create(object toolView)
        {
            var viewArgument = new ImplementedTypesConstructorArgument(toolView, true);
            return this.resolutionRoot.Get<IRibbonToolController<TDefinition>>(viewArgument);
        }
    }
}