namespace Ribbonizer.Media
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    [ExcludeFromCodeCoverage]
    internal class ImageSourceFactory : IImageSourceFactory
    {
        public ImageSource Create(Uri uri)
        {
            return new BitmapImage(uri);
        }
    }
}