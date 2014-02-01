namespace Ribbonizer.ViewModel.Lifecycle
{
    using System.Collections.Generic;

    internal class LifecycleManager : ILifecycleManager
    {
        private readonly object viewModel;
        private readonly ILifecycleExtensionBuilder builder;
        private ICollection<ILifecycleExtension> lifecycleExtensions;

        public LifecycleManager(object viewModel, ILifecycleExtensionBuilder builder)
        {
            this.viewModel = viewModel;
            this.builder = builder;
        }

        public void Activate()
        {
            this.lifecycleExtensions = this.builder.Build(this.viewModel).ToCollection();

            this.lifecycleExtensions.ForEach(x => x.Activate());
        }

        public void Deactivate()
        {
            this.lifecycleExtensions.ForEach(x => x.Deactivate());
        }
    }
}