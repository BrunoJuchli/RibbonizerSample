namespace Ribbonizer.Ribbon
{
    using System;
    using System.Collections.Generic;

    internal class GroupedDefinitionData<TDefinition>
    {
        public IEnumerable<TDefinition> Definitions { get; set; }

        public Type ParentType { get; set; }
    }
}