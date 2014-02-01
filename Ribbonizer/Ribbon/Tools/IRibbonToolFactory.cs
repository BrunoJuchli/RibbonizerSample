namespace Ribbonizer.Ribbon.Tools
{
    internal interface IRibbonToolFactory<in TDefinition>
        where TDefinition : class, IRibbonToolDefinition
    {
        object CreateAndInitializeView();
    }
}