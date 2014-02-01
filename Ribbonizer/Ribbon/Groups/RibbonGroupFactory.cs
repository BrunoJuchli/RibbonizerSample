namespace Ribbonizer.Ribbon.Groups
{
    using System.Collections.Generic;

    using Ribbonizer.Ribbon.Wrapping;

    internal class RibbonGroupFactory : IRibbonViewFactory<IRibbonGroupDefinition, IRibbonGroupView, object>
    {
        private readonly IRibbonViewWrapperFactory wrapperFactory;

        public RibbonGroupFactory(IRibbonViewWrapperFactory wrapperFactory)
        {
            this.wrapperFactory = wrapperFactory;
        }

        public IRibbonGroupView CreateAndInitialize(IRibbonGroupDefinition definition, IEnumerable<object> childViews)
        {
            var groupView = this.wrapperFactory.CreateGroupView();
            groupView.Caption = definition.Caption;

            childViews.ForEach(groupView.AddItem);

            return groupView;
        }
    }
}