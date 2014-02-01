namespace Ribbonizer.Ribbon.DefinitionValidation
{
    using System.Collections.Generic;

    internal interface IRibbonDefinitionValidator
    {
        IEnumerable<IRibbonDefinitionViolation> Validate();
    }
}