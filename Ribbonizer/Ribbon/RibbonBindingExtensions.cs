namespace Ribbonizer.Ribbon
{
    using System;

    using Ninject.Syntax;

    public static class RibbonBindingExtensions
    {
        public static IBindingWhenInNamedWithOrOnSyntax<object> BindRibbonDefinition<TBinding>(this IBindingRoot bindingRoot, Type type)
        {
            return bindingRoot
                .Bind(typeof(TBinding))
                .To(type);
        }
    }
}