namespace RibbonizerSample.Contacts
{
    using System.Globalization;

    using PropertyChanged;

    [ImplementPropertyChanged]
    public class ContactViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Organization { get; set; }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0} '{1} {2}'",
                this.GetType().Name,
                this.FirstName,
                this.LastName);
        }
    }
}