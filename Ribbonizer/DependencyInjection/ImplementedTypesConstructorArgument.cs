namespace Ribbonizer.DependencyInjection
{
    using System;

    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Planning.Targets;

    public class ImplementedTypesConstructorArgument : ITypedParameter, IConstructorArgument
    {
        public ImplementedTypesConstructorArgument(object argumentValue, bool shouldInherit)
        {
            this.ArgumentType = argumentValue.GetType();
            this.ArgumentValue = argumentValue;
            this.ShouldInherit = shouldInherit;

            this.Name = this.ArgumentType.FullName;
        }

        public string Name { get; private set; }

        public bool ShouldInherit { get; private set; }

        public Type ArgumentType { get; private set; }

        public object ArgumentValue { get; private set; }

        public bool MatchesType(Type type)
        {
            return this.IsArgumentType(type) || this.IsInterfaceOfArgumentType(type);
        }

        public bool Equals(IParameter other)
        {
            return other.GetType() == this.GetType() && other.Name.Equals(this.Name);
        }

        public object GetValue(IContext context, ITarget target)
        {
            return this.ArgumentValue;
        }

        public bool AppliesToTarget(IContext context, ITarget target)
        {
            if (string.IsNullOrEmpty(target.Name))
            {
                // the target constructor parameter name is null, when it's for a .ToFactory bound Interceptor
                // this kind of interceptor get injected an object parameter
                // this would result in two parameters being available for the same target (parameter) - an absolute no go.
                // so this how we work around that.
                // change this and the wrath of the coder god will be upon you!
                // you will die a slow and painful death. You will never touch a keyboard again.
                // When you take a mouse into your hands it will be melted into your hands.
                return false;
            }

            return this.MatchesType(target.Type);
        }

        private bool IsArgumentType(Type type)
        {
            return type == this.ArgumentType;
        }

        private bool IsInterfaceOfArgumentType(Type type)
        {
            return type.IsInterface && type.IsInstanceOfType(this.ArgumentValue);
        }
    }
}