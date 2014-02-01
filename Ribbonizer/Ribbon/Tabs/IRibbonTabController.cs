namespace Ribbonizer.Ribbon.Tabs
{
    internal interface IRibbonTabController
    {
        void Show(IRibbonTabView tabView);

        void Hide(IRibbonTabView tabView);
    }
}