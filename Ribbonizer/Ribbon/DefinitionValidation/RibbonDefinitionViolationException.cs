namespace Ribbonizer.Ribbon.DefinitionValidation
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using System.Text;

    using Ribbonizer.Reflection;

    [Serializable]
    public class RibbonDefinitionViolationException : Exception
    {
        private const string DefaultMessage = "Ribbon definition validation failed with the following violations:";

        public RibbonDefinitionViolationException()
            : this(Enumerable.Empty<IRibbonDefinitionViolation>())
        {
        }

        public RibbonDefinitionViolationException(string message)
            : this(new Collection<IRibbonDefinitionViolation>(), message, null)
        {
        }

        public RibbonDefinitionViolationException(string message, Exception innerException)
            : this(new Collection<IRibbonDefinitionViolation>(), message, innerException)
        {
        }

        public RibbonDefinitionViolationException(IEnumerable<IRibbonDefinitionViolation> violations)
            : this(violations.ToCollection(), DefaultMessage, null)
        {
        }

        protected RibbonDefinitionViolationException(ICollection<IRibbonDefinitionViolation> violations, string message, Exception innerException)
            : base(BuildMessage(message, violations), innerException)
        {
            this.Violations = violations;            
        }

        protected RibbonDefinitionViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public IEnumerable<IRibbonDefinitionViolation> Violations { get; private set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(Reflector<RibbonDefinitionViolationException>.GetPropertyName(x => x.Violations), this.Violations);
            base.GetObjectData(info, context);
        }

        private static string BuildMessage(string preamble, IEnumerable<IRibbonDefinitionViolation> violations)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(preamble);
            
            violations.ForEach(violation =>
            {
                stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "<-----------------------------------"));
                stringBuilder.AppendLine(violation.Message);
            });

            return stringBuilder.ToString();
        }
    }
}