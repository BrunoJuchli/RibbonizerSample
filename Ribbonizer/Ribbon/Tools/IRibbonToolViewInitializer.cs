namespace Ribbonizer.Ribbon.Tools
{
    internal interface IRibbonToolViewInitializer<in TDefinition> where TDefinition : class, IRibbonToolDefinition
    {
        object Initialize();
    }
}