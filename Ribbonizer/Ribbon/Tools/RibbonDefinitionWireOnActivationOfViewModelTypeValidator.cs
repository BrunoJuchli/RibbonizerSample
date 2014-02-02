namespace Ribbonizer.Ribbon.Tools
{
    using System.Collections.Generic;
    using System.Linq;

    using Ribbonizer.Ribbon.DefinitionValidation;

    internal class RibbonDefinitionWireOnActivationOfViewModelTypeValidator<TDefinition> : IRibbonDefinitionValidator
        where TDefinition : IRibbonToolDefinition
    {
        private readonly IEnumerable<TDefinition> definitions;

        public RibbonDefinitionWireOnActivationOfViewModelTypeValidator(IEnumerable<TDefinition> definitions)
        {
            this.definitions = definitions;
        }

        public IEnumerable<IRibbonDefinitionViolation> Validate()
        {
            return this.definitions
                .Where(definition => !definition.WireOnActivationOfViewModelType.IsClass)
                .Select(definition => new RibbonDefinitionWireOnActivationOfViewModelTypeIsNotClassViolation(definition, definition.WireOnActivationOfViewModelType));
        }
    }
}