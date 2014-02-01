namespace Ribbonizer.Ribbon.Tabs
{
    using System.Globalization;

    using Ribbonizer.Reflection;
    using Ribbonizer.Ribbon.DefinitionValidation;

    internal class RibbonDefinitionShowOnActivationOfViewModelTypeIsNotClassViolation : IRibbonDefinitionViolation
    {
        private const string MessageFormat = "The tab definition {0}'s {1} {2} is not a class type.";

        private readonly IRibbonTabDefinition definition;

        public RibbonDefinitionShowOnActivationOfViewModelTypeIsNotClassViolation(IRibbonTabDefinition definition)
        {
            this.definition = definition;
        }

        public string Message
        {
            get
            {
                string propertyName = Reflector<IRibbonTabDefinition>.GetPropertyName(x => x.ShowOnActivationOfViewModelType);
                return string.Format(CultureInfo.InvariantCulture, MessageFormat, this.definition.GetType().FullName, propertyName, this.definition.ShowOnActivationOfViewModelType.FullName); 
            }
        }
    }
}