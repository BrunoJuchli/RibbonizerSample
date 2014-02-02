namespace Ribbonizer.Ribbon.Tabs
{
    using System;

    public interface IRibbonTabDefinition
    {
        string Header { get; }

        Type ShowOnActivationOfViewModelType { get; }
    }
}