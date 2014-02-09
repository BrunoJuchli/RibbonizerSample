namespace RibbonizerSample.SampleTracking
{
    using Ribbonizer.ViewModel.Lifecycle;

    public class ActivationLoggingExtension : ILifecycleExtension
    {
        private static int index = 0;
        private readonly object viewModel;

        private readonly IViewModelActivationLoggingCollection activationLoggingCollection;

        private readonly IActivatedViewModelsCollection activatedViewModels;

        public ActivationLoggingExtension(object viewModel, IViewModelActivationLoggingCollection activationLoggingCollection, IActivatedViewModelsCollection activatedViewModels)
        {
            this.viewModel = viewModel;
            this.activationLoggingCollection = activationLoggingCollection;
            this.activatedViewModels = activatedViewModels;
        }

        public void Activate()
        {
            this.activatedViewModels.Add(this.viewModel.ToString());
            this.activationLoggingCollection.Add(string.Format("{0}: {1} + Activated", index++, this.viewModel));
        }

        public void Deactivate()
        {
            this.activatedViewModels.Remove(this.viewModel.ToString());
            this.activationLoggingCollection.Add(string.Format("{0}: {1} - Deactivated", index++, this.viewModel));
        }
    }
}