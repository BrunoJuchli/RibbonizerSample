namespace Ribbonizer.Wrappers.Microsoft
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Controls;
    using System.Windows.Controls.Ribbon;

    using Ribbonizer.Ribbon.Groups;

    [ExcludeFromCodeCoverage]
    internal class RibbonGroupWrapper : IRibbonGroupView, IWrapper<RibbonGroup>
    {
        private readonly RibbonGroup ribbonGroup;

        public RibbonGroupWrapper(RibbonGroup ribbonGroup)
        {
            this.ribbonGroup = ribbonGroup;
        }

        public RibbonGroup Wrapped
        {
            get { return this.ribbonGroup; }
        }

        public string Caption
        {
            get { return this.ribbonGroup.Name; }
            set { this.ribbonGroup.Name = value; }
        }

        public void AddItem(object item)
        {
            var wrapper = item as IWrapper<Control>;
            if (wrapper != null)
            {
                this.ribbonGroup.Items.Add(wrapper.Wrapped);
            }
            else
            {
                this.ribbonGroup.Items.Add(item);
            }
        }
    }
}