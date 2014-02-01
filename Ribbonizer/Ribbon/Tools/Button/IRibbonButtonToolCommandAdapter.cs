namespace Ribbonizer.Ribbon.Tools.Button
{
    internal interface IRibbonButtonToolCommandAdapter : IRibbonButtonToolCommand
    {
        void BindCommand(IRibbonButtonToolCommand command, object viewModel);

        void UnbindCommand(object viewModel);
    }
}