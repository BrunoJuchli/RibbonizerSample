namespace Ribbonizer.ViewModel.Lifecycle
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Ninject;
    using Ninject.Syntax;

    using Ribbonizer.DependencyInjection;

    [ExcludeFromCodeCoverage]
    internal class LifecycleExtensionFactory : ILifecycleExtensionFactory
    {
        private readonly IResolutionRoot resolutionRoot;

        public LifecycleExtensionFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public ILifecycleExtension Create(Type type, object viewModel)
        {
            var viewModelConstructorArgument = new ImplementedTypesConstructorArgument(viewModel, false);
            var viewModelAsObjectConstructorArgument = new TypedConstructorArgument(typeof(object), viewModel, false);
            return this.resolutionRoot.Get(type, viewModelConstructorArgument, viewModelAsObjectConstructorArgument) as ILifecycleExtension;
        }
    }
}