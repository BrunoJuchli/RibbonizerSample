namespace Ribbonizer.Ribbon
{
    internal class RibbonProvider : IRibbonProvider, IRibbonProviderInitialization
    {
        public IRibbonView Ribbon { get; private set; }
        
        public void Initialize(IRibbonView ribbon)
        {
            this.Ribbon = ribbon;
        }
    }
}