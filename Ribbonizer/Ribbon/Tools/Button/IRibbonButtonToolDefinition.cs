namespace Ribbonizer.Ribbon.Tools.Button
{
    using System;
    using System.Collections.Generic;

    internal interface IRibbonButtonToolDefinition : IRibbonToolDefinition
    {
        IEnumerable<RibbonButtonToolCommandDefinition> CommandDefinitions { get; }

        string Caption { get; }

        string ToolTip { get; }

        Uri LargeImage { get; }
    }
}