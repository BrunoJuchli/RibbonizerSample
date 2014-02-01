namespace Ribbonizer.Ribbon.Tools.Button
{
    using System.Collections.Generic;
    using System.Linq;

    using Ribbonizer.Ribbon.DefinitionValidation;

    internal class RibbonButtonDefinitionWireOnActivationOfViewModelTypeValidator : IRibbonDefinitionValidator
    {
        private readonly IEnumerable<IRibbonButtonToolDefinition> definitions;

        public RibbonButtonDefinitionWireOnActivationOfViewModelTypeValidator(IEnumerable<IRibbonButtonToolDefinition> definitions)
        {
            this.definitions = definitions;
        }

        public IEnumerable<IRibbonDefinitionViolation> Validate()
        {
            return this.CheckDefinition().ToList();
        }

        private IEnumerable<IRibbonDefinitionViolation> CheckDefinition()
        {
            foreach (var definition in this.definitions)
            {
                foreach (var commandDefinition in definition.CommandDefinitions)
                {
                    if (!commandDefinition.WireOnActivationOfViewModelType.IsClass)
                    {
                        yield return new RibbonDefinitionWireOnActivationOfViewModelTypeIsNotClassViolation(definition, commandDefinition.WireOnActivationOfViewModelType);
                    }
                }

                bool commandTypeDuplicated = definition.CommandDefinitions.GroupBy(x => x.CommandType).Any(x => x.Count() > 1);
                bool viewModelDuplicated = definition.CommandDefinitions.GroupBy(x => x.WireOnActivationOfViewModelType).Any(x => x.Count() > 1);

                if (commandTypeDuplicated || viewModelDuplicated)
                {
                    yield return new RibbonDefinitionDuplicatedCommandsViolation(definition);
                }
            }
        }
    }
}