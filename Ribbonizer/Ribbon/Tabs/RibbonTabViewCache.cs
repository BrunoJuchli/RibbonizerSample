namespace Ribbonizer.Ribbon.Tabs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RibbonTabViewCache : IRibbonTabViewCache, IRibbonTabViewCacheInitializer
    {
        private readonly IRibbonViewBuilder<IRibbonTabDefinition, IRibbonTabView> tabBuilder;
        private readonly IEnumerable<IRibbonTabDefinition> tabDefinitions;
        private readonly Dictionary<Type, List<IRibbonTabView>> tabCache;

        public RibbonTabViewCache(
            IRibbonViewBuilder<IRibbonTabDefinition, IRibbonTabView> tabBuilder,
            IEnumerable<IRibbonTabDefinition> tabDefinitions)
        {
            this.tabBuilder = tabBuilder;
            this.tabDefinitions = tabDefinitions;

            this.tabCache = new Dictionary<Type, List<IRibbonTabView>>();
        }

        public void InitializeCache()
        {
            foreach (var tabDefinition in this.tabDefinitions)
            {
                this.BuildContextualTab(tabDefinition);
            }
        }

        public IEnumerable<IRibbonTabView> Retrieve(Type viewModelType)
        {
            if (this.tabCache.ContainsKey(viewModelType))
            {
                return this.tabCache[viewModelType];
            }

            return Enumerable.Empty<IRibbonTabView>();
        }

        private void BuildContextualTab(IRibbonTabDefinition tabDefinition)
        {
            IRibbonTabView ribbonTabView = this.tabBuilder.Build(tabDefinition);

            if (ribbonTabView != null)
            {
                this.AddTab(tabDefinition, ribbonTabView);
            }
        }

        private void AddTab(IRibbonTabDefinition tabDefinition, IRibbonTabView ribbonTabView)
        {
            if (!this.tabCache.ContainsKey(tabDefinition.ShowOnActivationOfViewModelType))
            {
                this.tabCache.Add(tabDefinition.ShowOnActivationOfViewModelType, new List<IRibbonTabView>());
            }

            this.tabCache[tabDefinition.ShowOnActivationOfViewModelType].Add(ribbonTabView);
        }
    }
}