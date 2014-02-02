namespace RibbonizerSample.Contacts
{
    using System;
    using System.Collections.Generic;

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
            yield return new AnonymousResult(() => Console.WriteLine("Creating Contact"));
        }
    }
}