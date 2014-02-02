namespace RibbonizerSample.Contacts
{
    using System.Collections.Generic;
    using System.Windows;

    using Caliburn.Micro;

    using Ribbonizer.Results;
    using Ribbonizer.Ribbon.Tools.Button;

    internal class CreateContactCommand : IRibbonButtonToolCommand
    {
        public bool CanExecute
        {
            get { return true; }
        }

        public IEnumerable<IResult> Execute()
        {
            yield return new AnonymousResult(() => MessageBox.Show("Creating Contact"));
        }
    }
}