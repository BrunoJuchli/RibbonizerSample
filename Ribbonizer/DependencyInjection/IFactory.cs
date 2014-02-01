namespace Ribbonizer.DependencyInjection
{
    public interface IFactory
    {
        T Create<T>();
    }
}