namespace Ribbonizer.Ribbon.Tools
{
    using System;

    internal interface IRibbonToolWireOnActivationDefinition : IRibbonToolDefinition
    {
        Type WireOnActivationOfViewModelType { get; }
    }
}