namespace Ribbonizer.Ribbon.Tools
{
    using System;

    internal interface IRibbonToolWiringFactory
    {
        T Create<T>(Type concreteType, object viewModel);
    }
}