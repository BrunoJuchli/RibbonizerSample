namespace RibbonizerSample.SampleTracking.TreeView
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ActivationTreeItem
    {
        private readonly object viewModel;

        public ActivationTreeItem(object viewModel)
        {
            this.viewModel = viewModel;
            this.ActiveChildren = new Collection<ActivationTreeItem>();
        }

        public string Name { get; set; }

        public ICollection<ActivationTreeItem> ActiveChildren { get; private set; }
    }
}