namespace RibbonizerSample.SampleTracking
{
    using Ribbonizer.ViewModel.Lifecycle;

    public class ActivationLoggingExtension : ILifecycleExtension
    {
        private readonly object viewModel;

        private readonly IViewModelActivationTrackingCollection activationTrackingCollection;

        public ActivationLoggingExtension(object viewModel, IViewModelActivationTrackingCollection activationTrackingCollection)
        {
            this.viewModel = viewModel;
            this.activationTrackingCollection = activationTrackingCollection;
        }

        public void Activate()
        {
            this.activationTrackingCollection.Add(string.Format("{0} + Activated", this.viewModel));
        }

        public void Deactivate()
        {
            this.activationTrackingCollection.Add(string.Format("{0} - Deactivated", this.viewModel));
        }
    }
}