namespace Ribbonizer.Ribbon.Tools
{
    using System;
    using System.Collections.Generic;

    using Ribbonizer.ViewModel.Lifecycle;

    internal class RibbonToolLifecycleExtension : ILifecycleExtension
    {
        private readonly object viewModel;
        private readonly IRibbonToolControllerCache controllerCache;

        public RibbonToolLifecycleExtension(object viewModel, IRibbonToolControllerCache controllerCache)
        {
            this.viewModel = viewModel;
            this.controllerCache = controllerCache;
        }

        public void Activate()
        {
            this.RetrieveToolControllers()
                .ForEach(controller => controller.WireTo(this.viewModel));
        }

        public void Deactivate()
        {
            this.RetrieveToolControllers()
                .ForEach(controller => controller.UnwireFrom(this.viewModel));
        }

        private IEnumerable<IRibbonToolController> RetrieveToolControllers()
        {
            Type viewModelType = this.viewModel.GetType();
            return this.controllerCache.Retrieve(viewModelType);
        }
    }
}