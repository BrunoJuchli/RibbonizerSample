namespace RibbonizerSample.SampleTracking
{
    using Ninject.Modules;

    using RibbonizerSample.SampleTracking.LoggingView;

    public class SampleTrackingModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IViewModelActivationLoggingCollection>()
                .To<ViewModelActivationLoggingCollection>()
                .InSingletonScope();
        }
    }
}