namespace Ribbonizer.ViewModel.Lifecycle.Activatable
{
    using System;

    public class DeactivatableConductorProvider : ILifecycleExtensionProvider
    {
        public Type Retrieve(object viewModel)
        {
            if (viewModel is IDeactivatable)
            {
                return typeof(DeactivatableConductor);
            }

            return null;
        }
    }
}