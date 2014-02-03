namespace RibbonizerSample
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using PropertyChanged;

    using RibbonizerSample.SampleTracking;

    [ImplementPropertyChanged]
    public class ShellViewModel
    {
        public ShellViewModel(IEnumerable<IPageViewModel> pages, ActivationLoggingViewModel activationLoggingViewModel)
        {
            this.ActivationLoggingViewModel = activationLoggingViewModel;
            this.Pages = new BindableCollection<IPageViewModel>(pages);
        }

        public ActivationLoggingViewModel ActivationLoggingViewModel { get; private set; }

        public IObservableCollection<IPageViewModel> Pages { get; private set; }

        public IPageViewModel SelectedPage { get; set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}