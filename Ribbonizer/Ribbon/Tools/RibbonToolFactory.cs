namespace Ribbonizer.Ribbon.Tools
{
    internal class RibbonToolFactory<TDefinition> : IRibbonToolFactory<TDefinition>
        where TDefinition : class, IRibbonToolDefinition
    {
        private readonly TDefinition definition;

        private readonly IRibbonToolViewInitializer<TDefinition> viewInitializer;
        private readonly IRibbonToolControllerFactory<TDefinition> controllerFactory;
        private readonly IRibbonToolControllerCache controllerCache;

        public RibbonToolFactory(
            TDefinition definition,
            IRibbonToolViewInitializer<TDefinition> viewInitializer,
            IRibbonToolControllerFactory<TDefinition> controllerFactory,
            IRibbonToolControllerCache controllerCache)
        {
            this.definition = definition;
            this.viewInitializer = viewInitializer;
            this.controllerFactory = controllerFactory;
            this.controllerCache = controllerCache;
        }

        public object CreateAndInitializeView()
        {
            object view = this.viewInitializer.Initialize();
            IRibbonToolController<TDefinition> controller = this.controllerFactory.Create(view);
            this.controllerCache.Register(this.definition.WireOnActivationOfViewModelType, controller);
            return view;
        }
    }
}