namespace Ribbonizer.Ribbon.DefinitionValidation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    internal class RibbonDefinitionSortIndexViolation : IRibbonDefinitionViolation
    {
        private const string MessageFormatParent = "{0}'s children have conflicting sort indexes (each sort index must be unique per parent):";
        private const string MessageFormatChild = "\t{0} : {1}";
        private const string MessageFormatConflictingChild = "-!- {0} : {1} (conflicting)";

        private readonly Type parentType;
        private readonly IEnumerable<IRibbonDefinitionWithParentType> allChildren;
        private readonly IEnumerable<IRibbonDefinitionWithParentType> conflictingChildren;

        public RibbonDefinitionSortIndexViolation(
            Type parentType, 
            IEnumerable<IRibbonDefinitionWithParentType> allChildren,
            IEnumerable<IRibbonDefinitionWithParentType> conflictingChildren)
        {
            this.parentType = parentType;
            this.allChildren = allChildren;
            this.conflictingChildren = conflictingChildren.ToCollection();
        }

        public string Message
        {
            get { return this.BuildMessage(); }
        }

        private string BuildMessage()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, MessageFormatParent, this.parentType.FullName));
            this.allChildren
                .ForEach(child =>
                {
                    if (this.conflictingChildren.Contains(child))
                    {
                        stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, MessageFormatConflictingChild, child.SortIndex, child.GetType().FullName));
                    }
                    else
                    {
                        stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, MessageFormatChild, child.SortIndex, child.GetType().FullName));
                    }
                });

            return stringBuilder.ToString();
        }
    }
}