namespace Ribbonizer.Wrappers.Microsoft
{
    using System.Windows.Controls;
    using System.Windows.Controls.Ribbon;

    using Ribbonizer.Ribbon.Groups;
    using Ribbonizer.Ribbon.Tabs;
    using Ribbonizer.Ribbon.Tools.Button;

    internal static class RibbonViewsWrapperExtensions
    {
        public static RibbonTab RetrieveWrapped(this IRibbonTabView tab)
        {
            return Retrieve<RibbonTab>(tab);
        }

        public static RibbonGroup RetrieveWrapped(this IRibbonGroupView group)
        {
            return Retrieve<RibbonGroup>(group);
        }

        public static Control RetrieveWrapped(this IRibbonButtonToolView tool)
        {
            return Retrieve<Control>(tool);
        }

        private static T Retrieve<T>(object wrapper)
        {
            return ((IWrapper<T>)wrapper).Wrapped;
        }
    }
}