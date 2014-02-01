namespace Ribbonizer.DependencyInjection
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "Used for Ninject binding")]
    public interface IUniqueBindingCollection<out T> : IEnumerable<T>
    {
    }
}