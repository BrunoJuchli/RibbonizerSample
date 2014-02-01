namespace Ribbonizer.Ribbon.Tools
{
    internal interface IRibbonToolControllerFactory<in TDefinition>
        where TDefinition : class, IRibbonToolDefinition
    {
        IRibbonToolController<TDefinition> Create(object toolView);
    }
}