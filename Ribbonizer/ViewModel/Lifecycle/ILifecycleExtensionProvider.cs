namespace Ribbonizer.ViewModel.Lifecycle
{
    using System;

    internal interface ILifecycleExtensionProvider
    {
        Type Retrieve(object viewModel);
    }
}