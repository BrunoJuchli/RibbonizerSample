namespace Ribbonizer
{
    using System;

    public static class Conventions
    {
        public static bool IsViewModel(this Type type)
        {
            return type.Name.EndsWith("ViewModel");
        }
    }
}