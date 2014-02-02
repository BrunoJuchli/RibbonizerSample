namespace Ribbonizer.Ribbon.Tools.Button
{
    internal class RibbonButtonToolController : IRibbonToolController<IRibbonButtonToolDefinition>
    {
        private readonly IRibbonButtonToolDefinition definition;
        private readonly IRibbonButtonToolCommandAdapter adapter;
        private readonly IRibbonToolWiringFactory wiringFactory;

        public RibbonButtonToolController(IRibbonButtonToolDefinition definition, IRibbonButtonToolCommandAdapter adapter, IRibbonToolWiringFactory wiringFactory)
        {
            this.definition = definition;
            this.adapter = adapter;
            this.wiringFactory = wiringFactory;
        }

        public void WireTo(object viewModel)
        {
            var command = this.wiringFactory.Create<IRibbonButtonToolCommand>(this.definition.CommandType, viewModel);
            this.adapter.BindCommand(command, viewModel);
        }

        public void UnwireFrom(object viewModel)
        {
            this.adapter.UnbindCommand(viewModel);
        }
    }
}