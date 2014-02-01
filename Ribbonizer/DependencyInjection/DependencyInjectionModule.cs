namespace Ribbonizer.DependencyInjection
{
    using Ninject.Modules;

    public class DependencyInjectionModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFactory>().To<Factory>();
            this.Bind(typeof(IUniqueBindingCollection<>)).To(typeof(UniqueBindingCollection<>));
        }
    }
}