namespace Ribbonizer.ViewModel.Lifecycle
{
    using System;

    internal interface ILifecycleExtensionFactory
    {
        ILifecycleExtension Create(Type type, object viewModel);
    }
}