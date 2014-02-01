namespace Ribbonizer.ViewModel.Lifecycle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ribbonizer.DependencyInjection;

    internal class LifecycleExtensionTypeCache : ILifecycleExtensionTypeCache
    {
        private readonly IUniqueBindingCollection<ILifecycleExtensionProvider> providers;
        private readonly Dictionary<Type, IEnumerable<Type>> cache;

        public LifecycleExtensionTypeCache(IUniqueBindingCollection<ILifecycleExtensionProvider> providers)
        {
            this.providers = providers;
            this.cache = new Dictionary<Type, IEnumerable<Type>>();
        }

        public IEnumerable<Type> RetrieveLifecycleExtensionTypes(object viewModel)
        {
            var viewModelType = viewModel.GetType();

            if (!this.cache.ContainsKey(viewModelType))
            {
                List<Type> lifecycleExtensionTypes = this.providers
                    .Select(provider => provider.Retrieve(viewModel))
                    .Where(type => type != null).ToList();

                this.cache.Add(viewModelType, lifecycleExtensionTypes);
            }

            return this.cache[viewModelType];
        }
    }
}