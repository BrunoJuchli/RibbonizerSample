namespace Ribbonizer.Wrappers.Microsoft
{
    using Ninject.Modules;

    using Ribbonizer.Ribbon;
    using Ribbonizer.Ribbon.Groups;
    using Ribbonizer.Ribbon.Tabs;
    using Ribbonizer.Ribbon.Tools.Button;

    public class MicrosoftRibbonWrappersModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMicrosoftRibbonViewWrapperFactory>().To<MicrosoftRibbonViewWrapperFactory>();
            this.BindWrappers();
        }

        private void BindWrappers()
        {
            this.Bind<IRibbonView>().To<RibbonWrapper>();
            this.Bind<IRibbonTabView>().To<RibbonTabWrapper>();
            this.Bind<IRibbonGroupView>().To<RibbonGroupWrapper>();
            this.Bind<IRibbonButtonToolView>().To<RibbonButtonToolWrapper>();
        }
    }
}