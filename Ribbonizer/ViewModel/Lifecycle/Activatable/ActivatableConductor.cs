namespace Ribbonizer.ViewModel.Lifecycle.Activatable
{
    internal class ActivatableConductor : ILifecycleExtension
    {
        private readonly IActivatable viewModel;

        public ActivatableConductor(IActivatable viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Activate()
        {
            this.viewModel.Activate();
        }

        public void Deactivate()
        {
        }
    }
}