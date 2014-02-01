namespace Ribbonizer.Ribbon
{
    internal interface IRibbonViewBuilder<in TDefinition, out TView>
        where TDefinition : class
        where TView : class
    {
        TView Build(TDefinition definition);
    }
}