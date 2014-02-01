namespace Ribbonizer.Ribbon.Tools.Button
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public IEnumerable<Type> WireOn
        {
            get
            {
                return this.definition.CommandDefinitions.Select(x => x.WireOnActivationOfViewModelType);
            }
        }

        public void WireTo(object viewModel)
        {
            RibbonButtonToolCommandDefinition commandDefinition = this.definition.CommandDefinitions.Single(x => x.WireOnActivationOfViewModelType == viewModel.GetType());
            var command = this.wiringFactory.Create<IRibbonButtonToolCommand>(commandDefinition.CommandType, viewModel);
            this.adapter.BindCommand(command, viewModel);
        }

        public void UnwireFrom(object viewModel)
        {
            this.adapter.UnbindCommand(viewModel);
        }
    }
}