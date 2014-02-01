namespace Ribbonizer.Ribbon.Tools
{
    using System;
    using System.Globalization;

    using Ribbonizer.Ribbon.DefinitionValidation;

    internal class RibbonDefinitionWireOnActivationOfViewModelTypeIsNotClassViolation : IRibbonDefinitionViolation
    {
        public const string MessageFormat = "The definition {0}'s view model type {1} is not a class type.";

        private readonly IRibbonToolDefinition definition;
        private readonly Type viewModelType;

        public RibbonDefinitionWireOnActivationOfViewModelTypeIsNotClassViolation(IRibbonToolDefinition definition, Type viewModelType)
        {
            this.definition = definition;
            this.viewModelType = viewModelType;
        }

        public string Message
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, MessageFormat, this.definition.GetType().FullName, this.viewModelType.FullName);
            }
        }
    }
}