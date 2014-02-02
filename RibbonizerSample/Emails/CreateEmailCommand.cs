namespace RibbonizerSample.Emails
{
    using System.Collections.Generic;
    using System.Windows;

    using Caliburn.Micro;

    using Ribbonizer.Results;
    using Ribbonizer.Ribbon.Tools.Button;

    internal class CreateEmailCommand : IRibbonButtonToolCommand
    {
        public bool CanExecute
        {
            get { return true; }
        }

        public IEnumerable<IResult> Execute()
        {
            yield return new AnonymousResult(() => MessageBox.Show("Creating E-Mail"));
        }
    }
}