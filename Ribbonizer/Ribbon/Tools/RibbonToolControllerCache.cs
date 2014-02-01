namespace Ribbonizer.Ribbon.Tools
{
    using System;
    using System.Collections.Generic;

    internal class RibbonToolControllerCache : IRibbonToolControllerCache
    {
        private readonly Dictionary<Type, List<IRibbonToolController>> cache;

        public RibbonToolControllerCache()
        {
            this.cache = new Dictionary<Type, List<IRibbonToolController>>();
        }

        public void Register(Type viewModelType, IRibbonToolController view)
        {
            this.RetrieveCacheEntry(viewModelType)
                .Add(view);
        }

        public IEnumerable<IRibbonToolController> Retrieve(Type viewModelType)
        {
            return this.RetrieveCacheEntry(viewModelType).ToArray();
        }

        private List<IRibbonToolController> RetrieveCacheEntry(Type viewModelType)
        {
            if (!this.cache.ContainsKey(viewModelType))
            {
                this.cache.Add(viewModelType, new List<IRibbonToolController>());
            }

            return this.cache[viewModelType];
        }
    }
}