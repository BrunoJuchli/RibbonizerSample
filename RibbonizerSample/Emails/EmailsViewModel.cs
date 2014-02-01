namespace RibbonizerSample.Emails
{
    using PropertyChanged;

    [ImplementPropertyChanged]
    public class EmailsViewModel : IPageViewModel
    {
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}