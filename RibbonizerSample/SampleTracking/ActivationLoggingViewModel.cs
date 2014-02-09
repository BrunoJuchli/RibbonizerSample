namespace RibbonizerSample.SampleTracking
{
    public class ActivationLoggingViewModel
    {
        public ActivationLoggingViewModel(IViewModelActivationLoggingCollection activationLoggingCollection, IActivatedViewModelsCollection activatedViewModelsCollection)
        {
            this.ActivatedViewModels = activatedViewModelsCollection;
            this.ActivationLoggingCollection = activationLoggingCollection;
        }

        public IViewModelActivationLoggingCollection ActivationLoggingCollection { get; private set; }

        public IActivatedViewModelsCollection ActivatedViewModels { get; private set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}