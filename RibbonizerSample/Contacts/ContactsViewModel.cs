namespace RibbonizerSample.Contacts
{
    using PropertyChanged;

    [ImplementPropertyChanged]
    public class ContactsViewModel : IPageViewModel
    {
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}