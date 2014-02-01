namespace Ribbonizer.Ribbon
{
    using System.Collections.Generic;
    using System.Linq;

    using Ribbonizer.Ribbon.DefinitionValidation;
    using Ribbonizer.Ribbon.Tabs;

    internal class RibbonInitializer : IRibbonInitializer
    {
        private readonly IEnumerable<IRibbonDefinitionValidator> definitionValidators;
        private readonly IRibbonTabViewCacheInitializer tabViewCacheInitializer;

        public RibbonInitializer(IEnumerable<IRibbonDefinitionValidator> definitionValidators, IRibbonTabViewCacheInitializer tabViewCacheInitializer)
        {
            this.definitionValidators = definitionValidators;
            this.tabViewCacheInitializer = tabViewCacheInitializer;
        }

        public void InitializeRibbonViewTree()
        {
            IEnumerable<IRibbonDefinitionViolation> violations = this.definitionValidators
                .SelectMany(x => x.Validate())
                .ToList();

            if (violations.Any())
            {
                throw new RibbonDefinitionViolationException(violations);
            }

            this.tabViewCacheInitializer.InitializeCache();
        }
    }
}