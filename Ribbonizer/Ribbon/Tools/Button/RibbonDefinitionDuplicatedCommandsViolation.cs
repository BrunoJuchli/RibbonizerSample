namespace Ribbonizer.Ribbon.Tools.Button
{
    using System.Globalization;

    using Ribbonizer.Ribbon.DefinitionValidation;

    internal class RibbonDefinitionDuplicatedCommandsViolation : IRibbonDefinitionViolation
    {
        public const string MessageFormat = "The definition {0} contains duplicated view models or commands. Inside the command definition a view model can only linked to one command";

        private readonly IRibbonButtonToolDefinition definition;

        public RibbonDefinitionDuplicatedCommandsViolation(IRibbonButtonToolDefinition definition)
        {
            this.definition = definition;
        }

        public string Message
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, MessageFormat, this.definition.GetType().FullName);
            }
        }
    }
}