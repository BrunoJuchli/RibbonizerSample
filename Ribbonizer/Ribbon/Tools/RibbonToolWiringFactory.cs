namespace Ribbonizer.Ribbon.Tools
{
    using System;

    using Ninject;
    using Ninject.Syntax;

    using Ribbonizer.DependencyInjection;

    internal class RibbonToolWiringFactory : IRibbonToolWiringFactory
    {
        private readonly IResolutionRoot resolutionRoot;

        public RibbonToolWiringFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public T Create<T>(Type concreteType, object viewModel)
        {
            var argument = new ImplementedTypesConstructorArgument(viewModel, true);
            return (T)this.resolutionRoot.Get(concreteType, argument);
        }
    }
}