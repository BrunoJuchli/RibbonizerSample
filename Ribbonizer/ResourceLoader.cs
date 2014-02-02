namespace Ribbonizer
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Windows.Media.Imaging;

    public static class ResourceLoader
    {
        public static BitmapImage GetImage<TType>(string imageName)
        {
            return new BitmapImage(BuildUri<TType>(imageName));
        }

        public static Uri BuildUri<TType>(string imageName)
        {
            return new Uri(BuildFrom<TType>(imageName));
        }

        private static string BuildFrom<TType>(string imageName)
        {
            Type type = typeof(TType);
            var typeAssembly = Assembly.GetAssembly(type);

            var resourcePath = imageName;
            if (type.Namespace != null && !imageName.Contains("/"))
            {
                var namespaceWithoutAssemblyName = type.Namespace
                    .Remove(0, typeAssembly.GetName().Name.Length + 1)
                    .Replace('.', '/');
                resourcePath = string.Format(CultureInfo.InvariantCulture, "{0}/{1}", namespaceWithoutAssemblyName, imageName);
            }

            return BuildFrom(typeAssembly.GetName().Name, resourcePath);
        }

        private static string BuildFrom(string assemblyName, string resourcePath)
        {
            string packUri = string.Format(
                CultureInfo.InvariantCulture, "pack://application:,,,/{0};component/{1}", assemblyName, resourcePath);

            return packUri;
        }
    }
}