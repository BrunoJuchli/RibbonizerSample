namespace Ribbonizer.Ribbon.Tabs
{
    using System.Collections.Generic;

    using Appccelerate;

    internal class RibbonTabController : IRibbonTabController
    {
        private readonly IRibbonProvider ribbonProvider;
        private readonly Dictionary<IRibbonTabView, IRibbonView> tabToRibbonMap;

        public RibbonTabController(IRibbonProvider ribbonProvider)
        {
            this.ribbonProvider = ribbonProvider;
            this.tabToRibbonMap = new Dictionary<IRibbonTabView, IRibbonView>();
        }

        public void Show(IRibbonTabView tabView)
        {
            IRibbonView ribbon = this.ribbonProvider.Ribbon;
            this.tabToRibbonMap.Add(tabView, ribbon);

            ribbon.AddTab(tabView);
        }

        public void Hide(IRibbonTabView tabView)
        {
            IRibbonView ribbon = this.ForgetAssociation(tabView);
            ribbon.RemoveTab(tabView);
        }

        private IRibbonView ForgetAssociation(IRibbonTabView tabView)
        {
            Ensure.ArgumentMatches(this.tabToRibbonMap.ContainsKey(tabView), "The contextual tab group was not shown before or has already been removed.");

            IRibbonView ribbon = this.tabToRibbonMap[tabView];
            this.tabToRibbonMap.Remove(tabView);
            return ribbon;
        }
    }
}