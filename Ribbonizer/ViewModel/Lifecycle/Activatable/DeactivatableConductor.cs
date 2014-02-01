namespace Ribbonizer.ViewModel.Lifecycle.Activatable
{
    internal class DeactivatableConductor : ILifecycleExtension
    {
        private readonly IDeactivatable viewModel;

        public DeactivatableConductor(IDeactivatable viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Activate()
        {
        }

        public void Deactivate()
        {
            this.viewModel.Deactivate();
        }
    }
}