namespace Ribbonizer.Ribbon.Tabs
{
    using System;

    using Ribbonizer.ViewModel.Lifecycle;

    internal class RibbonTabLifecycleExtensionProvider : ILifecycleExtensionProvider
    {
        public Type Retrieve(object viewModel)
        {
            return typeof(RibbonTabLifecycleExtension);
        }
    }
}