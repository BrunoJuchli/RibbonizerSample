namespace Ribbonizer.ViewModel.Lifecycle
{
    using System;

    internal class ChildrenConductorProvider : ILifecycleExtensionProvider
    {
        public Type Retrieve(object viewModel)
        {
            if (viewModel.GetType().Name.EndsWith("ViewModel"))
            {
                return typeof(ChildrenConductor);
            }

            return null;
        }
    }
}