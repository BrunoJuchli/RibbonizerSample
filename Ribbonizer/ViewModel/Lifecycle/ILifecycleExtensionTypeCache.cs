namespace Ribbonizer.ViewModel.Lifecycle
{
    using System;
    using System.Collections.Generic;

    internal interface ILifecycleExtensionTypeCache
    {
        IEnumerable<Type> RetrieveLifecycleExtensionTypes(object viewModel);
    }
}