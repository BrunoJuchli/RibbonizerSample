namespace Ribbonizer.Ribbon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RibbonChildrenViewBuilder<TChildDefinition, TChildView> : IRibbonChildrenViewBuilder<TChildView>
        where TChildDefinition : class, IRibbonDefinitionWithParentType
        where TChildView : class
    {
        private readonly IRibbonViewBuilder<TChildDefinition, TChildView> childViewBuilder;
        private readonly IGroupedDefinitionProvider<TChildDefinition> childDefinitionProvider;

        public RibbonChildrenViewBuilder(IRibbonViewBuilder<TChildDefinition, TChildView> childViewBuilder, IGroupedDefinitionProvider<TChildDefinition> childDefinitionProvider)
        {
            this.childViewBuilder = childViewBuilder;
            this.childDefinitionProvider = childDefinitionProvider;
        }

        public IEnumerable<TChildView> Build(Type parentDefinitionType)
        {
            return this.childDefinitionProvider
                .RetrieveSortedDefinitions(parentDefinitionType)
                .Select(this.childViewBuilder.Build)
                .Where(x => x != null)
                .ToList();
        }
    }
}