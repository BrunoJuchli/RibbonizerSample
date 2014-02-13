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
        private readonly IObservableCollection<EmailViewModel> emails;
        private readonly IObservableCollection<EmailViewModel> selectedEmails;

        public EmailListViewModel()
        {
            var now = DateTimeOffset.Now;
            this.emails = new BindableCollection<EmailViewModel>
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

            this.selectedEmails = new BindableCollection<EmailViewModel>();
        }

        public string Header
        {
            get { return "Mail"; }
        }

        public ImageSource Image
        {
            get { return ResourceLoader.GetImage<EmailListViewModel>("mail.ico"); }
        }

        public IObservableCollection<EmailViewModel> Emails
        {
            get { return this.emails; }
        }

        public IObservableCollection<EmailViewModel> SelectedEmails
        {
            get { return this.selectedEmails; }
        }

        public void HandleSelectionChanged(SelectionChangedEventArgs eventArgs)
        {
            this.SelectedEmails.RemoveRange(eventArgs.RemovedItems.OfType<EmailViewModel>());
            this.SelectedEmails.AddRange(eventArgs.AddedItems.OfType<EmailViewModel>());
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }

        public void Deactivate()
        {
            this.SelectedEmails.Clear();
        }
    }
}