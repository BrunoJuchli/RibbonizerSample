namespace Ribbonizer.Ribbon.Tabs
{
    using System;

    public interface IRibbonTabDefinition
    {
        string Header { get; }

        /// <summary>
        /// The ribbon will the displayed when a ViewModel of this type is activated
        /// and will be hidden when it's deactivated.
        /// </summary>
        Type ShowOnActivationOfViewModelType { get; }
    }
}