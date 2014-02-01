namespace Ribbonizer.DependencyInjection
{
    using Ninject;
    using Ninject.Syntax;

    internal class Factory : IFactory
    {
        private readonly IResolutionRoot resolutionRoot;

        public Factory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public T Create<T>()
        {
            return this.resolutionRoot.Get<T>();
        }
    }
}