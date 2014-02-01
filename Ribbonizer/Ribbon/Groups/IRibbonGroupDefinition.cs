namespace Ribbonizer.Ribbon.Groups
{
    internal interface IRibbonGroupDefinition : IRibbonDefinitionWithParentType
    {
        string Caption { get; }
    }
}