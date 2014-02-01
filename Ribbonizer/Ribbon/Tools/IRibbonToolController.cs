namespace Ribbonizer.Ribbon.Tools
{
    using System;
    using System.Collections.Generic;

    internal interface IRibbonToolController
    {
        IEnumerable<Type> WireOn { get; }

        void WireTo(object viewModel);

        void UnwireFrom(object viewModel);
    }

    internal interface IRibbonToolController<in TDefinition> : IRibbonToolController
        where TDefinition : class, IRibbonToolDefinition
    {
    }
}