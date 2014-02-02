namespace Ribbonizer.Ribbon.Tools
{
    internal interface IRibbonToolController
    {
        void WireTo(object viewModel);

        void UnwireFrom(object viewModel);
    }

    internal interface IRibbonToolController<in TDefinition> : IRibbonToolController
        where TDefinition : class, IRibbonToolDefinition
    {
    }
}