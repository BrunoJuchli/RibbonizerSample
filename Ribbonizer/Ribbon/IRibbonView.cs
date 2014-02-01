namespace Ribbonizer.Ribbon
{
    using Ribbonizer.Ribbon.Tabs;

    public interface IRibbonView
    {
        void AddTab(IRibbonTabView tabView);

        void RemoveTab(IRibbonTabView tabView);
    }
}