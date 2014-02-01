namespace Ribbonizer.Ribbon.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Castle.DynamicProxy.Generators.Emitters;

    using Ninject;
    using Ninject.Syntax;

    using Ribbonizer.DependencyInjection;
    using Ribbonizer.Reflection;

    internal class RibbonToolBuilder : IRibbonViewBuilder<IRibbonToolDefinition, object>
    {
        private static readonly ICollection<Type> IgnoredInterfaces = BuildIgnoredInterfaces().ToList();
        private static readonly string FactoryMethodName = Reflector<IRibbonToolFactory<IRibbonToolDefinition>>.GetMethod(x => x.CreateAndInitializeView()).Name;

        private readonly IResolutionRoot resolutionRoot;

        public RibbonToolBuilder(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public object Build(IRibbonToolDefinition definition)
        {
            Type toolDefinitionInterfaceType = definition.GetType()
                .GetAllInterfaces()
                .Single(x => !IgnoredInterfaces.Contains(x));

            var definitionArgument = new TypedConstructorArgument(toolDefinitionInterfaceType, definition, true);

            Type factoryType = typeof(IRibbonToolFactory<>).MakeGenericType(toolDefinitionInterfaceType);

            object factory = this.resolutionRoot.Get(factoryType, definitionArgument);

            return factoryType.GetMethod(FactoryMethodName).Invoke(factory, new object[0]);
        }

        private static IEnumerable<Type> BuildIgnoredInterfaces()
        {
            var baseInterface = typeof(IRibbonToolDefinition);
            var wireInterface = typeof(IRibbonToolWireOnActivationDefinition);
            return new[] { baseInterface, wireInterface }
                .Concat(baseInterface.GetInterfaces());
        }
    }
}