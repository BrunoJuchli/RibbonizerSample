namespace Ribbonizer.ViewModel.Lifecycle
{
    using System.Collections.Generic;

    internal interface ILifecycleExtensionBuilder
    {
        IEnumerable<ILifecycleExtension> Build(object viewModel);
    }
}