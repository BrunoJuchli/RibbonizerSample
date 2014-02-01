namespace Ribbonizer.Ribbon.Groups
{
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;

    using Ribbonizer.DependencyInjection;
    using Ribbonizer.Ribbon.DefinitionValidation;
    using Ribbonizer.Ribbon.Tabs;
    using Ribbonizer.Ribbon.Tools.Button;

    public class RibbonGroupsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRibbonViewBuilder<IRibbonGroupDefinition, IRibbonGroupView>>()
                .To<RibbonViewWithChildrenBuilder<IRibbonGroupDefinition, IRibbonGroupView, object>>();

            this.Bind<IRibbonViewFactory<IRibbonGroupDefinition, IRibbonGroupView, object>>().To<RibbonGroupFactory>();

            this.Bind<IRibbonChildrenViewBuilder<IRibbonGroupView>>().To<RibbonChildrenViewBuilder<IRibbonGroupDefinition, IRibbonGroupView>>();

            this.BindValidators();

            this.BindDefinitionsByConvention();

            this.Kernel.Load<RibbonButtonToolModule>();
        }

        private void BindValidators()
        {
            this.Bind<IRibbonDefinitionValidator>().To<RibbonDefinitionParentTypeValidator<IRibbonGroupDefinition, IRibbonTabDefinition>>();
            this.Bind<IRibbonDefinitionValidator>().To<RibbonDefinitionSortIndexValidator<IRibbonGroupDefinition>>();
        }

        private void BindDefinitionsByConvention()
        {
            this.Bind(x => x
                .FromProductionAssemblies()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InheritedFrom<IRibbonGroupDefinition>()
                .BindWith<RibbonBindingGenerator<IRibbonGroupDefinition>>());
        }
    }
}