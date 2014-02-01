namespace Ribbonizer.DependencyInjection
{
    using System;

    using Ninject.Parameters;

    public interface ITypedParameter : IParameter
    {
        object ArgumentValue { get; }

        bool MatchesType(Type type);
    }
}