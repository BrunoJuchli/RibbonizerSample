namespace Ribbonizer.Ribbon
{
    using System;

    public interface IRibbonDefinitionWithParentType
    {
        /// <summary>
        /// This references to the parent type.
        /// For group definitions, it needs to be a tab.
        /// For tool definitions, it needs to be a group.
        /// </summary>
        Type ParentType { get; }

        int SortIndex { get; }
    }
}