namespace Ribbonizer.ViewModel.Lifecycle.Children
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    public class SingleChildConductor : ILifecycleExtension
    {
        private readonly ILifecycleController lifecycleController;
        private readonly INotifyPropertyChanged viewModelNotifyPropertyChanged;
        private readonly object viewModel;

        private ICollection<ChildViewModelProperty> childViewModelProperties;

        public SingleChildConductor(ILifecycleController lifecycleController, object viewModel)
        {
            this.lifecycleController = lifecycleController;
            this.viewModel = viewModel;
            this.viewModelNotifyPropertyChanged = (INotifyPropertyChanged)viewModel;
        }

        public void Activate()
        {
            this.viewModelNotifyPropertyChanged.PropertyChanged += this.HandlePropertyChanged;

            this.childViewModelProperties = this.viewModel
                .GetType()
                .GetProperties()
                .Where(IsViewModelProperty)
                .Select(x => new ChildViewModelProperty(x, this.viewModel, this.lifecycleController))
                .ToList();

            this.childViewModelProperties.ForEach(x => x.ActivateChild());
        }

        public void Deactivate()
        {
            this.viewModelNotifyPropertyChanged.PropertyChanged -= this.HandlePropertyChanged;

            this.childViewModelProperties.ForEach(x => x.DeactivateChild());
            this.childViewModelProperties.Clear();
            this.childViewModelProperties = null;
        }

        private static bool IsViewModelProperty(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetGetMethod().ReturnType.IsViewModel();
        }
        
        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ChildViewModelProperty childViewModelProperty = this.childViewModelProperties.SingleOrDefault(x => x.PropertyName == e.PropertyName);
            if (childViewModelProperty != null)
            {
                childViewModelProperty.DeactivateChild();
                childViewModelProperty.ActivateChild();
            }
        }

        private class ChildViewModelProperty
        {
            private readonly PropertyInfo property;
            private readonly object viewModel;
            private readonly ILifecycleController lifecycleController;

            private object activatedChild;

            public ChildViewModelProperty(PropertyInfo property, object viewModel, ILifecycleController lifecycleController)
            {
                this.property = property;
                this.viewModel = viewModel;
                this.lifecycleController = lifecycleController;
            }

            public string PropertyName
            {
                get { return this.property.Name; }
            }
            
            public void ActivateChild()
            {
                this.activatedChild = this.RetrievePropertyValue();
                if (this.activatedChild != null)
                {
                    this.lifecycleController.Activate(this.activatedChild);
                }
            }

            public void DeactivateChild()
            {
                if (this.activatedChild != null)
                {
                    this.lifecycleController.Deactivate(this.activatedChild);
                    this.activatedChild = null;
                }
            }

            private object RetrievePropertyValue()
            {
                return this.property.GetGetMethod().Invoke(this.viewModel, new object[0]);
            }
        }
    }
}