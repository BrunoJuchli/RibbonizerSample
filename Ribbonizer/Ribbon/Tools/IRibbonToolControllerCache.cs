namespace Ribbonizer.Ribbon.Tools
{
    using System;
    using System.Collections.Generic;

    internal interface IRibbonToolControllerCache
    {
        void Register(Type viewModelType, IRibbonToolController controller);

        IEnumerable<IRibbonToolController> Retrieve(Type viewModelType);
    }
}