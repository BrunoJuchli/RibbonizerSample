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

        public ShellViewModel(IFactory factory, ActivationLoggingViewModel activationLoggingViewModel)
        {
            this.ActivationLoggingViewModel = activationLoggingViewModel;
            this.factory = factory;
        }

        public ActivationLoggingViewModel ActivationLoggingViewModel { get; private set; }

        public IPageViewModel Page { get; private set; }

        public void PageSelectionChanged(SelectionChangedEventArgs eventArgs)
        {
            if (eventArgs.AddedItems.Count == 1)
            {
                var addedItem = (NavigationPaneItem)eventArgs.AddedItems[0];
                switch ((string)addedItem.Header)
                {
                    case "Contacts":
                        this.ChangeToPage<ContactListViewModel>();
                        break;
                    case "Mail":
                        this.ChangeToPage<EmailListViewModel>();
                        break;
                    default:
                        throw new NotSupportedException(string.Format("unsupported page '{0}'", addedItem.Header));
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