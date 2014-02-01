namespace Ribbonizer.Ribbon.DefinitionValidation
{
    using System.Collections.Generic;
    using System.Linq;

    internal class RibbonDefinitionSortIndexValidator<TDefinition> : IRibbonDefinitionValidator
        where TDefinition : class, IRibbonDefinitionWithParentType
    {
        private readonly IGroupedDefinitionProvider<TDefinition> definitionProvider;

        public RibbonDefinitionSortIndexValidator(IGroupedDefinitionProvider<TDefinition> definitionProvider)
        {
            this.definitionProvider = definitionProvider;
        }

        public IEnumerable<IRibbonDefinitionViolation> Validate()
        {
            return this.definitionProvider
                .RetrieveAll()
                .SelectMany(ValidateGroup);
        }

        private static IEnumerable<RibbonDefinitionSortIndexViolation> ValidateGroup(GroupedDefinitionData<TDefinition> definitionData)
        {
            IEnumerable<TDefinition> violatingDefinitions = definitionData.Definitions
                .GroupBy(x => x.SortIndex)
                .Where(x => x.Count() > 1)
                .SelectMany(x => x)
                .ToList();

            if (violatingDefinitions.Any())
            {
                yield return new RibbonDefinitionSortIndexViolation(definitionData.ParentType, definitionData.Definitions, violatingDefinitions);
            }
        }
    }
}