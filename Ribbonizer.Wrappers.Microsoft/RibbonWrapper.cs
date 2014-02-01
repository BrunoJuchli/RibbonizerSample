namespace Ribbonizer.Wrappers.Microsoft
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Controls.Ribbon;

    using Ribbonizer.Ribbon;
    using Ribbonizer.Ribbon.Tabs;

    [ExcludeFromCodeCoverage]
    internal class RibbonWrapper : IRibbonView
    {
        private readonly Ribbon ribbon;

        public RibbonWrapper(Ribbon ribbon)
        {
            this.ribbon = ribbon;
        }

        public void AddTab(IRibbonTabView tabView)
        {
            RibbonTab tab = tabView.RetrieveWrapped();
            this.ribbon.Items.Add(tab);
            this.ribbon.SelectedItem = tab;
        }

        public void RemoveTab(IRibbonTabView tabView)
        {
            RibbonTab tab = tabView.RetrieveWrapped();
            this.ribbon.Items.Remove(tab);
        }
    }
}