namespace RibbonizerSample.Emails
{
    using System.Collections.Generic;
    using System.Windows;

    using Caliburn.Micro;

    using Ribbonizer.Results;
    using Ribbonizer.Ribbon.Tools.Button;

    internal class DeleteEmailCommand : IRibbonButtonToolCommand
    {
        private readonly EmailViewModel viewModel;

        public DeleteEmailCommand(EmailViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute
        {
            get { return true; }
        }

        public IEnumerable<IResult> Execute()
        {
            yield return new AnonymousResult(() => MessageBox.Show(string.Format("deleting '{0}'", this.viewModel.Subject)));
        }
    }
}