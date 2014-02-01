namespace RibbonizerSample
{
    using System;
    using System.Windows.Controls;

    using PropertyChanged;

    using Ribbonizer.DependencyInjection;

    using RibbonizerSample.Contacts;
    using RibbonizerSample.Emails;

    using Stema.Controls;

    [ImplementPropertyChanged]
    public class ShellViewModel
    {
        private readonly IFactory factory;

        public ShellViewModel(IFactory factory)
        {
            this.factory = factory;
        }

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

        private void ChangeToPage<T>()
            where T : IPageViewModel
        {
            this.Page = this.factory.Create<T>();
        }
    }
}