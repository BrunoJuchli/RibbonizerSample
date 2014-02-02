namespace RibbonizerSample.Emails
{
    using System;

    using PropertyChanged;

    [ImplementPropertyChanged]
    public class EmailViewModel
    {
        public string Sender { get; set; }

        public string Subject { get; set; }

        public DateTimeOffset Received { get; set; }

        public bool Read { get; set; }
    }
}