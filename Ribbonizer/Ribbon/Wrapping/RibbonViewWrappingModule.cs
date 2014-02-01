namespace Ribbonizer.Ribbon.Wrapping
{
    using Ninject.Extensions.Factory;
    using Ninject.Modules;

    public class RibbonViewWrappingModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRibbonViewWrapperFactory>().ToFactory();
        }
    }
}