namespace RibbonizerSample.SampleTracking
{
    using Ribbonizer.ViewModel.Lifecycle;

    public class ActivationLoggingExtension : ILifecycleExtension
    {
        private readonly object viewModel;

        private readonly IViewModelActivationLoggingCollection activationLoggingCollection;

        public ActivationLoggingExtension(object viewModel, IViewModelActivationLoggingCollection activationLoggingCollection)
        {
            this.viewModel = viewModel;
            this.activationLoggingCollection = activationLoggingCollection;
        }

        public void Activate()
        {
            this.activationLoggingCollection.Add(string.Format("{0} + Activated", this.viewModel));
        }

        public void Deactivate()
        {
            this.activationLoggingCollection.Add(string.Format("{0} - Deactivated", this.viewModel));
        }
    }
}