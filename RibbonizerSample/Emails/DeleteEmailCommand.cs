namespace RibbonizerSample.Emails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Caliburn.Micro;
    using Ribbonizer.Results;
    using Ribbonizer.Ribbon.Tools.Button;

    internal class DeleteEmailCommand : PropertyChangedBase, IRibbonButtonToolCommand
    {
        private readonly EmailListViewModel viewModel;

        public DeleteEmailCommand(EmailListViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.viewModel.SelectedItems.CollectionChanged += this.HandleCollectionChanged;
        }

        public bool CanExecute
        {
            get { return this.viewModel.SelectedItems.Any(); }
        }

        public IEnumerable<IResult> Execute()
        {
            var toDelete = this.viewModel.SelectedItems.ToList();
            yield return new AnonymousResult(() => this.viewModel.Emails.RemoveRange(toDelete));
        }

        private void HandleCollectionChanged(object sender, EventArgs e)
        {
            this.NotifyOfPropertyChange(() => this.CanExecute);
        }
    }
}