namespace Ribbonizer.Wrappers.Microsoft
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Controls;
    using System.Windows.Controls.Ribbon;
    using System.Windows.Media;

    using Caliburn.Micro;

    using Ribbonizer.Reflection;
    using Ribbonizer.Ribbon.Tools.Button;

    [ExcludeFromCodeCoverage]
    internal class RibbonButtonToolWrapper : IRibbonButtonToolView, IWrapper<Control>
    {
        private static readonly string ActionName = Reflector<IRibbonButtonToolCommand>.GetMethod(x => x.Execute()).Name;

        private readonly RibbonButton buttonTool;

        public RibbonButtonToolWrapper(RibbonButton buttonTool)
        {
            this.buttonTool = buttonTool;
        }

        public string Caption
        {
            get { return this.buttonTool.Label; }
            set { this.buttonTool.Label = value; }
        }

        public ImageSource LargeImage
        {
            get { return this.buttonTool.LargeImageSource; }
            set { this.buttonTool.LargeImageSource = value; }
        }

        public object ToolTip
        {
            get { return this.buttonTool.ToolTip; }
            set { this.buttonTool.ToolTip = value; }
        }

        public Control Wrapped
        {
            get { return this.buttonTool; }
        }

        public void WireExecute(IRibbonButtonToolCommand command)
        {
            Message.SetAttach(this.buttonTool, ActionName);
            Action.SetTarget(this.buttonTool, command);
        }
    }
}