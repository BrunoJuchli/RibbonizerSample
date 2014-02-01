namespace RibbonizerSample.SampleTracking
{
    using Ninject.Modules;

    public class SampleTrackingModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IViewModelActivationTrackingCollection>()
                .To<ViewModelActivationTrackingCollection>()
                .InSingletonScope();
        }
    }
}