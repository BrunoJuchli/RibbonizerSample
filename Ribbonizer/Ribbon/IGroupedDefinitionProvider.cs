namespace Ribbonizer.Ribbon
{
    using System;
    using System.Collections.Generic;

    internal interface IGroupedDefinitionProvider<TDefinition>
        where TDefinition : class, IRibbonDefinitionWithParentType
    {
        IEnumerable<TDefinition> RetrieveSortedDefinitions(Type parentType);

        IEnumerable<GroupedDefinitionData<TDefinition>> RetrieveAll();
    }
}