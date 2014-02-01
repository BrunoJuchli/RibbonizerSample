namespace Ribbonizer.Ribbon.DefinitionValidation
{
    using System.Globalization;

    internal class RibbonDefinitionParentTypeViolation<TParentInterface> : IRibbonDefinitionViolation
        where TParentInterface : class
    {
        private const string MessageFormat = "Definition {0}'s parent type must be a {1}. The current value is {2}.";

        private readonly IRibbonDefinitionWithParentType definition;

        public RibbonDefinitionParentTypeViolation(IRibbonDefinitionWithParentType definition)
        {
            this.definition = definition;
        }

        public string Message
        {
            get { return string.Format(CultureInfo.InvariantCulture, MessageFormat, this.definition.GetType().FullName, typeof(TParentInterface).Name, this.definition.ParentType.Name); }
        }
    }
}