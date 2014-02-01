namespace Ribbonizer.ViewModel.Lifecycle
{
    using System.Collections.Generic;

    using Appccelerate;

    internal class LifecycleController : ILifecycleController
    {
        private readonly ILifecycleManagerFactory managerFactory;
        private readonly Dictionary<object, ILifecycleManager> managers;

        public LifecycleController(ILifecycleManagerFactory managerFactory)
        {
            this.managerFactory = managerFactory;
            this.managers = new Dictionary<object, ILifecycleManager>();
        }

        public void Activate(object viewModel)
        {
            Ensure.ArgumentMatches(!this.managers.ContainsKey(viewModel), viewModel, "viewModel", "The view model is already activated.");

            ILifecycleManager manager = this.managerFactory.Create(viewModel);
            this.managers.Add(viewModel, manager);
                
            manager.Activate();
        }

        public void Deactivate(object viewModel)
        {
            Ensure.ArgumentMatches(this.managers.ContainsKey(viewModel), viewModel, "viewModel", "The view model is not activated.");

            ILifecycleManager manager = this.managers[viewModel];
            manager.Deactivate();

            this.managers.Remove(viewModel);
        }
    }
}