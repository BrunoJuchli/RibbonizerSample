namespace Ribbonizer.Ribbon.Tabs
{
    using System;
    using System.Collections.Generic;

    using Ribbonizer.ViewModel.Lifecycle;

    internal class RibbonTabLifecycleExtension : ILifecycleExtension
    {
        private readonly object viewModel;
        private readonly IRibbonTabViewCache cache;
        private readonly IRibbonTabController tabController;

        public RibbonTabLifecycleExtension(object viewModel, IRibbonTabViewCache cache, IRibbonTabController tabController)
        {
            this.viewModel = viewModel;
            this.cache = cache;
            this.tabController = tabController;
        }

        public void Activate()
        {
            this.RetrieveTabs()
                .ForEach(tab => this.tabController.Show(tab));
        }

        public void Deactivate()
        {
            this.RetrieveTabs()
                .ForEach(tab => this.tabController.Hide(tab));
        }

        private IEnumerable<IRibbonTabView> RetrieveTabs()
        {
            Type viewModelType = this.viewModel.GetType();
            return this.cache.Retrieve(viewModelType);
        }
    }
}