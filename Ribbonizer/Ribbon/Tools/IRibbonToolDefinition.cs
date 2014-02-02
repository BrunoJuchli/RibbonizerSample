namespace Ribbonizer.Ribbon.Tools
{
    using System;

    public interface IRibbonToolDefinition : IRibbonDefinitionWithParentType
    {
        Type WireOnActivationOfViewModelType { get; }
    }
}