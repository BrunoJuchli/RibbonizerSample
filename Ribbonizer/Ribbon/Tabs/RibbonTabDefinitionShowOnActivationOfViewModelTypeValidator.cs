namespace Ribbonizer.Ribbon.Tabs
{
    using System.Collections.Generic;
    using System.Linq;

    using Ribbonizer.Ribbon.DefinitionValidation;

    internal class RibbonTabDefinitionShowOnActivationOfViewModelTypeValidator<TDefinition> : IRibbonDefinitionValidator
        where TDefinition : IRibbonTabDefinition
    {
        private readonly IEnumerable<TDefinition> definitions;

        public RibbonTabDefinitionShowOnActivationOfViewModelTypeValidator(IEnumerable<TDefinition> definitions)
        {
            this.definitions = definitions;
        }

        public IEnumerable<IRibbonDefinitionViolation> Validate()
        {
            return this.definitions
                .Where(definition => !definition.ShowOnActivationOfViewModelType.IsClass)
                .Select(definition => new RibbonDefinitionShowOnActivationOfViewModelTypeIsNotClassViolation(definition));
        }
    }
}