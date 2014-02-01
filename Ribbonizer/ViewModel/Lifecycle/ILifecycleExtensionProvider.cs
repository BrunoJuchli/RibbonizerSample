namespace Ribbonizer.ViewModel.Lifecycle
{
    using System;

    public interface ILifecycleExtensionProvider
    {
        Type Retrieve(object viewModel);
    }
}