namespace RibbonizerSample.SampleTracking
{
    using Ninject.Modules;

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