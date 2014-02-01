namespace Ribbonizer.Ribbon.Tabs
{
    using System;

    internal interface IRibbonTabDefinition
    {
        string Header { get; }

        Type ShowOnActivationOfViewModelType { get; }
    }
}