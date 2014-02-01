namespace Ribbonizer.Ribbon.Groups
{
    using Ninject.Modules;

    using Ribbonizer.Ribbon.DefinitionValidation;
    using Ribbonizer.Ribbon.Tabs;

    public class RibbonGroupsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRibbonViewBuilder<IRibbonGroupDefinition, IRibbonGroupView>>()
                .To<RibbonViewWithChildrenBuilder<IRibbonGroupDefinition, IRibbonGroupView, object>>();

            this.Bind<IRibbonViewFactory<IRibbonGroupDefinition, IRibbonGroupView, object>>().To<RibbonGroupFactory>();

            this.Bind<IRibbonChildrenViewBuilder<IRibbonGroupView>>().To<RibbonChildrenViewBuilder<IRibbonGroupDefinition, IRibbonGroupView>>();

            this.BindValidators();
        }

        private void BindValidators()
        {
            this.Bind<IRibbonDefinitionValidator>().To<RibbonDefinitionParentTypeValidator<IRibbonGroupDefinition, IRibbonTabDefinition>>();
            this.Bind<IRibbonDefinitionValidator>().To<RibbonDefinitionSortIndexValidator<IRibbonGroupDefinition>>();
        }
    }
}