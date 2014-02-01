namespace Ribbonizer.Media
{
    using System;
    using System.Windows.Media;

    public interface IImageSourceFactory
    {
        ImageSource Create(Uri uri);
    }
}