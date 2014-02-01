namespace Ribbonizer.Ribbon.Tools.Button
{
    using Ribbonizer.Media;

    internal class RibbonButtonToolViewInitializer : IRibbonToolViewInitializer<IRibbonButtonToolDefinition>
    {
        private readonly IImageSourceFactory imageSourceFactory;
        private readonly IRibbonButtonToolDefinition definition;
        private readonly IRibbonButtonToolView view;
        private readonly IRibbonButtonToolCommandAdapter adapter;

        public RibbonButtonToolViewInitializer(
            IImageSourceFactory imageSourceFactory, 
            IRibbonButtonToolDefinition definition,
            IRibbonButtonToolView view, 
            IRibbonButtonToolCommandAdapter adapter)
        {
            this.imageSourceFactory = imageSourceFactory;
            this.definition = definition;
            this.view = view;
            this.adapter = adapter;
        }

        public object Initialize()
        {
            this.view.Caption = this.definition.Caption;
            this.view.LargeImage = this.imageSourceFactory.Create(this.definition.LargeImage);
            this.view.ToolTip = this.definition.ToolTip;
            this.view.WireExecute(this.adapter);
            return this.view;
        }
    }
}