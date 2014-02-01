namespace Ribbonizer.Ribbon.DefinitionValidation
{
    using System.Collections.Generic;
    using System.Linq;

    internal class RibbonDefinitionParentTypeValidator<TDefinition, TParentInterface> : IRibbonDefinitionValidator
        where TDefinition : IRibbonDefinitionWithParentType
        where TParentInterface : class
    {
        private readonly IEnumerable<TDefinition> definitions;

        public RibbonDefinitionParentTypeValidator(IEnumerable<TDefinition> definitions)
        {
            this.definitions = definitions;
        }

        public IEnumerable<IRibbonDefinitionViolation> Validate()
        {
            return this.definitions
                .Where(definition => !definition.ParentType.IsClass || !typeof(TParentInterface).IsAssignableFrom(definition.ParentType))
                .Select(definition => new RibbonDefinitionParentTypeViolation<TParentInterface>(definition));
        }
    }
}