namespace Ribbonizer.Wrappers.Microsoft
{
    using System.Windows.Controls.Ribbon;

    using Ribbonizer.Ribbon;

    public interface IMicrosoftRibbonViewWrapperFactory
    {
        IRibbonView CreateRibbonWrapper(Ribbon ribbon);
    }
}