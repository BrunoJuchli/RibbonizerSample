namespace Ribbonizer.Ribbon
{
    using System.Collections.Generic;

    internal interface IRibbonViewFactory<in TDefinition, out TView, in TChildView>
        where TDefinition : class
        where TView : class
        where TChildView : class
    {
        TView CreateAndInitialize(TDefinition definition, IEnumerable<TChildView> childViews);
    }
}