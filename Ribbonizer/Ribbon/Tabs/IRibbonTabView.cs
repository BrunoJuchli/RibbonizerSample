namespace Ribbonizer.Ribbon.Tabs
{
    using Ribbonizer.Ribbon.Groups;

    public interface IRibbonTabView : IRibbonViewWithChildren<IRibbonGroupView>
    {
        object Header { get; set; }
    }
}