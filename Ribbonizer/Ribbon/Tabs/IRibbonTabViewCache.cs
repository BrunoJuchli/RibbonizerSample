namespace Ribbonizer.Ribbon.Tabs
{
    using System;
    using System.Collections.Generic;

    internal interface IRibbonTabViewCache
    {
        IEnumerable<IRibbonTabView> Retrieve(Type viewModelType);
    }
}