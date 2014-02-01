namespace Ribbonizer.Ribbon
{
    using System;
    using System.Collections.Generic;

    using Ninject.Extensions.Conventions.BindingGenerators;
    using Ninject.Syntax;

    internal class RibbonBindingGenerator<TBinding> : IBindingGenerator
    {
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
        {
            yield return bindingRoot.BindRibbonDefinition<TBinding>(type);
        }
    }
}