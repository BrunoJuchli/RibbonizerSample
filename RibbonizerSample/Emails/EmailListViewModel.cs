namespace RibbonizerSample.Emails
{
    using System;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Caliburn.Micro;

    using PropertyChanged;
    using Ribbonizer;
    using Ribbonizer.ViewModel.Lifecycle.Activatable;

    [ImplementPropertyChanged]
    public class EmailListViewModel : IPageViewModel, IDeactivatable
    {
        public EmailListViewModel()
        {
            var now = DateTimeOffset.Now;

            this.Emails = new BindableCollection<EmailViewModel>
                              {
                                  new EmailViewModel
                                      {
                                          Sender = "Margaret G. Melton",
                                          Subject = "Sanitary Checks Tomorrow",
                                          Received = now.Subtract(TimeSpan.FromMinutes(2))
                                      },   
                                  new EmailViewModel
                                      {
                                          Sender = "Samuel B. Sanchez",
                                          Subject = "More Rats in the Study",
                                          Received = now.Subtract(TimeSpan.FromDays(1))
                                      },
                                    new EmailViewModel
                                      {
                                          Sender = "Samuel B. Sanchez",
                                          Subject = "Rats in the Basement",
                                          Received = now.Subtract(TimeSpan.FromHours(25))
                                      },
                                    new EmailViewModel
                                      {
                                          Sender = "Janice K. Burson",
                                          Subject = "Dirty Chicken Sink",
                                          Received = now.Subtract(TimeSpan.FromDays(2))
                                      }
                              };

            this.SelectedItems = new BindableCollection<EmailViewModel>();
        }

        public string Header
        {
            get { return "Mail"; }
        }

        public ImageSource Image
        {
            get { return ResourceLoader.GetImage<EmailListViewModel>("mail.ico"); }
        }

        public IObservableCollection<EmailViewModel> Emails { get; private set; }

        public IObservableCollection<EmailViewModel> SelectedItems { get; private set; }

        public void HandleSelectionChanged(SelectionChangedEventArgs eventArgs)
        {
            this.SelectedItems.RemoveRange(eventArgs.RemovedItems.OfType<EmailViewModel>());
            this.SelectedItems.AddRange(eventArgs.AddedItems.OfType<EmailViewModel>());
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }

        public void Deactivate()
        {
            this.SelectedItems.Clear();
        }
    }
}