namespace RibbonizerSample.SampleTracking.LoggingView
{
    public class ActivationLoggingViewModel
    {
        public ActivationLoggingViewModel(IViewModelActivationLoggingCollection activationLoggingCollection)
        {
            this.ActivationLoggingCollection = activationLoggingCollection;
        }

        public IViewModelActivationLoggingCollection ActivationLoggingCollection { get; private set; }
    }
}