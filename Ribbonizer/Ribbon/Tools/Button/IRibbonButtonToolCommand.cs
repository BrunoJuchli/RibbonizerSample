namespace Ribbonizer.Ribbon.Tools.Button
{
    using System.Collections.Generic;

    using Caliburn.Micro;

    public interface IRibbonButtonToolCommand
    {
        bool CanExecute { get; }

        IEnumerable<IResult> Execute();
    }
}