namespace RibbonizerSample.Emails
{
    using System;

    using Caliburn.Micro;

    using PropertyChanged;

    [ImplementPropertyChanged]
    public class EmailListViewModel : IPageViewModel
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
        }

        public IObservableCollection<EmailViewModel> Emails { get; private set; }

        public EmailViewModel SelectedItem { get; set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}