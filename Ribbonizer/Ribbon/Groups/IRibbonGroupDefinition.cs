namespace Ribbonizer.Ribbon.Groups
{
    public interface IRibbonGroupDefinition : IRibbonDefinitionWithParentType
    {
        string Caption { get; }
    }
}