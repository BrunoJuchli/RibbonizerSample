namespace RibbonizerSample
{
    using System;
    using System.Windows.Controls;

    using PropertyChanged;

    using Ribbonizer.DependencyInjection;

    using RibbonizerSample.Contacts;
    using RibbonizerSample.Emails;
    using RibbonizerSample.SampleTracking;

    using Stema.Controls;

    [ImplementPropertyChanged]
    public class ShellViewModel
    {
        private readonly IFactory factory;

        public ShellViewModel(IFactory factory, IViewModelActivationTrackingCollection activationTrackingCollection)
        {
            this.ActivationTrackingCollection = activationTrackingCollection;
            this.factory = factory;
        }

        public IViewModelActivationTrackingCollection ActivationTrackingCollection { get; set; }

        public IPageViewModel Page { get; private set; }

        public void PageSelectionChanged(SelectionChangedEventArgs eventArgs)
        {
            if (eventArgs.AddedItems.Count == 1)
            {
                var addedItem = (NavigationPaneItem)eventArgs.AddedItems[0];
                switch ((string)addedItem.Header)
                {
                    case "Contacts":
                        this.ChangeToPage<ContactsViewModel>();
                        break;
                    case "Mail":
                        this.ChangeToPage<EmailsViewModel>();
                        break;
                    default:
                        throw new NotImplementedException(string.Format("unsupported page '{0}'", addedItem.Header));
                }
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }

        private void ChangeToPage<T>()
            where T : IPageViewModel
        {
            this.Page = this.factory.Create<T>();
        }
    }
}