namespace Ribbonizer.Ribbon.Wrapping
{
    using Ribbonizer.Ribbon.Groups;
    using Ribbonizer.Ribbon.Tabs;

    internal interface IRibbonViewWrapperFactory
    {
        IRibbonTabView CreateTab();

        IRibbonGroupView CreateGroupView();
    }
}