namespace Ribbonizer.Wrappers.Microsoft
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Controls.Ribbon;

    using Ribbonizer.Ribbon.Groups;
    using Ribbonizer.Ribbon.Tabs;

    [ExcludeFromCodeCoverage]
    internal class RibbonTabWrapper : IRibbonTabView, IWrapper<RibbonTab>
    {
        private readonly RibbonTab tab;

        public RibbonTabWrapper(RibbonTab tab)
        {
            this.tab = tab;
        }

        public RibbonTab Wrapped
        {
            get { return this.tab; }
        }

        public object Header
        {
            get { return this.tab.Header; }
            set { this.tab.Header = value; }
        }

        public void AddItem(IRibbonGroupView item)
        {
            this.tab.Items.Add(item.RetrieveWrapped());
        }
    }
}