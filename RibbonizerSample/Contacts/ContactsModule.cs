namespace RibbonizerSample.Contacts
{
    using Ninject.Modules;

    public class ContactsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPageViewModel>().To<ContactListViewModel>();
        }
    }
}