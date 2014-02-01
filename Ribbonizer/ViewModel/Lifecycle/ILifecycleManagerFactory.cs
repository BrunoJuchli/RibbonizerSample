namespace Ribbonizer.ViewModel.Lifecycle
{
    internal interface ILifecycleManagerFactory
    {
        ILifecycleManager Create(object viewModel);
    }
}