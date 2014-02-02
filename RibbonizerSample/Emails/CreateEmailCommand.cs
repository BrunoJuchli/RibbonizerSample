namespace RibbonizerSample.Emails
{
    using System;
    using System.Collections.Generic;

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
            yield return new AnonymousResult(() => Console.WriteLine("Creating E-Mail"));
        }
    }
}