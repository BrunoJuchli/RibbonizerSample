namespace Ribbonizer.ViewModel.Lifecycle
{
    using System.Collections.Generic;
    using System.Linq;

    internal class LifecycleExtensionBuilder : ILifecycleExtensionBuilder
    {
        private readonly ILifecycleExtensionTypeCache cache;
        private readonly ILifecycleExtensionFactory lifecycleExtensionFactory;

        public LifecycleExtensionBuilder(ILifecycleExtensionTypeCache cache, ILifecycleExtensionFactory lifecycleExtensionFactory)
        {
            this.cache = cache;
            this.lifecycleExtensionFactory = lifecycleExtensionFactory;
        }

        public IEnumerable<ILifecycleExtension> Build(object viewModel)
        {
            return this.cache.RetrieveLifecycleExtensionTypes(viewModel)
                .Select(type => this.lifecycleExtensionFactory.Create(type, viewModel));
        }
    }
}