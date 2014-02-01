namespace Ribbonizer.Ribbon
{
    using System.Collections.Generic;
    using System.Linq;

    internal class RibbonViewWithChildrenBuilder<TParentDefinition, TParentView, TChildView> : IRibbonViewBuilder<TParentDefinition, TParentView>
        where TParentDefinition : class
        where TParentView : class, IRibbonViewWithChildren<TChildView>
        where TChildView : class
    {
        private readonly IRibbonViewFactory<TParentDefinition, TParentView, TChildView> parentViewFactory;
        private readonly IRibbonChildrenViewBuilder<TChildView> childrenViewBuilder;

        public RibbonViewWithChildrenBuilder(
            IRibbonViewFactory<TParentDefinition, TParentView, TChildView> parentViewFactory,
            IRibbonChildrenViewBuilder<TChildView> childrenViewBuilder)
        {
            this.parentViewFactory = parentViewFactory;
            this.childrenViewBuilder = childrenViewBuilder;
        }

        public TParentView Build(TParentDefinition definition)
        {
            IEnumerable<TChildView> childViews = this.childrenViewBuilder.Build(definition.GetType()).ToList();

            if (childViews.Any())
            {
                return this.parentViewFactory.CreateAndInitialize(definition, childViews);
            }

            return null;
        }
    }
}