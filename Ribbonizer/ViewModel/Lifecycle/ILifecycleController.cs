namespace Ribbonizer.ViewModel.Lifecycle
{
    public interface ILifecycleController
    {
        void Activate(object viewModel);

        void Deactivate(object viewModel);
    }
}