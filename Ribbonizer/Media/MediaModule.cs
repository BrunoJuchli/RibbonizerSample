namespace Ribbonizer.Media
{
    using Ninject.Modules;

    public class MediaModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IImageSourceFactory>().To<ImageSourceFactory>();
        }
    }
}