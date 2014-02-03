namespace Ribbonizer.Ribbon.Tools.Button
{
    using System;

    public interface IRibbonButtonToolDefinition : IRibbonToolDefinition
    {
        string Caption { get; }

        string ToolTip { get; }

        Uri LargeImage { get; }

        /// <summary>
        /// The Implementation of the command which provides the Guard and the Execute-Action for this Ribbon Tool.
        /// </summary>
        Type CommandType { get; }
    }
}