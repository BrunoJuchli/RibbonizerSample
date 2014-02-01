namespace Ribbonizer.Ribbon
{
    using System;
    using System.Collections.Generic;

    internal interface IRibbonChildrenViewBuilder<out TChildView>
    {
        IEnumerable<TChildView> Build(Type parentDefinitionType);
    }
}