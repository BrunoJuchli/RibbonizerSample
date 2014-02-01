namespace Ribbonizer.ViewModel.Lifecycle.Activatable
{
    using System;

    internal class ActivatableConductorProvider : ILifecycleExtensionProvider
    {
        public Type Retrieve(object viewModel)
        {
            if (viewModel is IActivatable)
            {
                return typeof(ActivatableConductor);
            }

            return null;
        }
    }
}