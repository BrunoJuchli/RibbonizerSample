namespace Ribbonizer.ViewModel.Lifecycle.Children
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    internal class SingleChildConductorProvider : ILifecycleExtensionProvider
    {
        public Type Retrieve(object viewModel)
        {
            Type viewModelType = viewModel.GetType();
            if (viewModelType.IsViewModel() && viewModelType.GetInterfaces().Contains(typeof(INotifyPropertyChanged)))
            {
                return typeof(SingleChildConductor);
            }

            return null;
        }
    }
}