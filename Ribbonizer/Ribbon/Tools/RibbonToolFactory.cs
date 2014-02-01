namespace Ribbonizer.Ribbon.Tools
{
    internal class RibbonToolFactory<TDefinition> : IRibbonToolFactory<TDefinition>
        where TDefinition : class, IRibbonToolDefinition
    {
        private readonly IRibbonToolViewInitializer<TDefinition> viewInitializer;
        private readonly IRibbonToolControllerFactory<TDefinition> controllerFactory;
        private readonly IRibbonToolControllerCache controllerCache;

        public RibbonToolFactory(
            IRibbonToolViewInitializer<TDefinition> viewInitializer,
            IRibbonToolControllerFactory<TDefinition> controllerFactory,
            IRibbonToolControllerCache controllerCache)
        {
            this.viewInitializer = viewInitializer;
            this.controllerFactory = controllerFactory;
            this.controllerCache = controllerCache;
        }

        public object CreateAndInitializeView()
        {
            object view = this.viewInitializer.Initialize();
            IRibbonToolController<TDefinition> controller = this.controllerFactory.Create(view);
            controller.WireOn.ForEach(x => this.controllerCache.Register(x, controller));
            return view;
        }
    }
}