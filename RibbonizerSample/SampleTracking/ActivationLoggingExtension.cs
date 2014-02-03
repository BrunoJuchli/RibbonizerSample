namespace RibbonizerSample.SampleTracking
{
    using Ribbonizer.ViewModel.Lifecycle;

    public class ActivationLoggingExtension : ILifecycleExtension
    {
        private static int index = 0;
        private readonly object viewModel;

        private readonly IViewModelActivationLoggingCollection activationLoggingCollection;

        public ActivationLoggingExtension(object viewModel, IViewModelActivationLoggingCollection activationLoggingCollection)
        {
            this.viewModel = viewModel;
            this.activationLoggingCollection = activationLoggingCollection;
        }

        public void Activate()
        {
            this.activationLoggingCollection.Add(string.Format("{0}: {1} + Activated", index++, this.viewModel));
        }

        public void Deactivate()
        {
            this.activationLoggingCollection.Add(string.Format("{0}: {1} - Deactivated", index++, this.viewModel));
        }
    }
}