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
            return this.definitions
                .Where(x => !x.WireOnActivationOfViewModelType.IsClass)
                .Select(x => new RibbonDefinitionWireOnActivationOfViewModelTypeIsNotClassViolation(x, x.WireOnActivationOfViewModelType));
        }
    }
}