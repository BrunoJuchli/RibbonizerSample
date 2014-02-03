namespace RibbonizerSample.Emails
{
    using Ninject.Modules;

    public class EmailModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPageViewModel>().To<EmailListViewModel>();
        }
    }
}