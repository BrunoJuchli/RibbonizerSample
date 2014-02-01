namespace Ribbonizer.Ribbon.Tools.Button
{
    using System.Windows.Media;

    public interface IRibbonButtonToolView
    {
        string Caption { get; set; }

        ImageSource LargeImage { get; set; }

        object ToolTip { get; set; }

        void WireExecute(IRibbonButtonToolCommand command);
    }
}