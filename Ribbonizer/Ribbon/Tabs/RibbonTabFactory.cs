namespace Ribbonizer.Ribbon.Tabs
{
    using System.Collections.Generic;

    using Ribbonizer.Ribbon.Groups;
    using Ribbonizer.Ribbon.Wrapping;

    internal class RibbonTabFactory : IRibbonViewFactory<IRibbonTabDefinition, IRibbonTabView, IRibbonGroupView>
    {
        private readonly IRibbonViewWrapperFactory wrapperFactory;

        public RibbonTabFactory(IRibbonViewWrapperFactory wrapperFactory)
        {
            this.wrapperFactory = wrapperFactory;
        }

        public IRibbonTabView CreateAndInitialize(IRibbonTabDefinition definition, IEnumerable<IRibbonGroupView> childViews)
        {
            IRibbonTabView tab = this.wrapperFactory.CreateTab();
            tab.Header = definition.Header;

            childViews.ForEach(tab.AddItem);

            return tab;
        }
    }
}