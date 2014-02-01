namespace Ribbonizer.Ribbon.Tools
{
    using System;

    using Ribbonizer.ViewModel.Lifecycle;

    internal class RibbonToolLifecycleExtensionProvider : ILifecycleExtensionProvider
    {
        public Type Retrieve(object viewModel)
        {
            return typeof(RibbonToolLifecycleExtension);
        }
    }
}