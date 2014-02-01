namespace Ribbonizer.Ribbon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class GroupedDefinitionProvider<TDefinition> : IGroupedDefinitionProvider<TDefinition>
        where TDefinition : class, IRibbonDefinitionWithParentType
    {
        private readonly IList<TDefinition> definitions;

        public GroupedDefinitionProvider(IEnumerable<TDefinition> definitions)
        {
            this.definitions = definitions.ToList();
        }

        public IEnumerable<TDefinition> RetrieveSortedDefinitions(Type parentType)
        {
            return this.definitions.Where(x => x.ParentType == parentType)
                .OrderBy(x => x.SortIndex)
                .ToList();
        }

        public IEnumerable<GroupedDefinitionData<TDefinition>> RetrieveAll()
        {
            return this.definitions.GroupBy(x => x.ParentType)
                .Select(x => new GroupedDefinitionData<TDefinition> { ParentType = x.Key, Definitions = x.ToList() });
        }
    }
}