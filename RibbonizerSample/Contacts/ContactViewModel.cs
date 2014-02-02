namespace RibbonizerSample.Contacts
{
    using PropertyChanged;

    [ImplementPropertyChanged]
    public class ContactViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Organization { get; set; }
    }
}