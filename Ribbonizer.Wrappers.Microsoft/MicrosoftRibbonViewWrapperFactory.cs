namespace Ribbonizer.Wrappers.Microsoft
{
    using System.Windows.Controls.Ribbon;

    using Ribbonizer.Ribbon;

    internal class MicrosoftRibbonViewWrapperFactory : IMicrosoftRibbonViewWrapperFactory
    {
        public IRibbonView CreateRibbonWrapper(Ribbon ribbon)
        {
            return new RibbonWrapper(ribbon);
        }
    }
}