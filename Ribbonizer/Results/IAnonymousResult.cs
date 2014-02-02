namespace Ribbonizer.Results
{
    using System.Diagnostics.CodeAnalysis;

    using Caliburn.Micro;

    [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "This interface is used as marker interface")]
    public interface IAnonymousResult : IResult
    {
    }
}