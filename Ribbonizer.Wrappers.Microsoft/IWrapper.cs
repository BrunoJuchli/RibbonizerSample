namespace Ribbonizer.Wrappers.Microsoft
{
    internal interface IWrapper<out T>
    {
        T Wrapped { get; }
    }
}