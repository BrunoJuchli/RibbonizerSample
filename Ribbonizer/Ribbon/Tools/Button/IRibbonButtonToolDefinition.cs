namespace Ribbonizer.Ribbon.Tools.Button
{
    using System;

    public interface IRibbonButtonToolDefinition : IRibbonToolDefinition
    {
        string Caption { get; }

        string ToolTip { get; }

        Uri LargeImage { get; }

        Type CommandType { get; }
    }
}