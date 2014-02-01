namespace Ribbonizer
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Text;

    public static class ObjectExtensions
    {
        public static void ExecuteIfInstanceIsOfType<T>(this object instance, Action<T> action)
            where T : class
        {
            var instanceOfType = instance as T;
            if (instanceOfType != null)
            {
                action(instanceOfType);
            }
        }

        public static string ShallowDumpToString(this object value, IFormatProvider formatProvider)
        {
            var sb = new StringBuilder();

            if (value == null)
            {
                sb.Append("null");
            }
            else
            {
                Type objectType = value.GetType();

                sb.AppendFormat(formatProvider, "{0}[", objectType.Name);

                var enumerable = value as IEnumerable;
                if (enumerable != null)
                {
                    int index = 0;
                    foreach (var val in enumerable)
                    {
                        sb.AppendFormat(formatProvider, "{0} = \"{1}\", ", index++, ConvertValueToString(val, formatProvider));
                    }
                }
                else
                {
                    foreach (PropertyInfo publicProperty in objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        object propertyValue = publicProperty.GetValue(value, null);
                        sb.AppendFormat(formatProvider, "{0} = \"{1}\", ", publicProperty.Name, ConvertValueToString(propertyValue, formatProvider));
                    }
                }

                sb = sb.Remove(sb.Length - 2, 2);
                sb.Append("]");
            }

            return sb.ToString();
        }

        private static string ConvertValueToString(object propertyValue, IFormatProvider formatProvider)
        {
            IFormattable formattableValue = (propertyValue as IFormattable) ?? new FakeFormattable(propertyValue);

            return formattableValue.ToString(null, formatProvider);
        }

        private class FakeFormattable : IFormattable
        {
            private readonly object formattingObject;

            public FakeFormattable(object value)
            {
                this.formattingObject = value;
            }

            public string ToString(string format, IFormatProvider formatProvider)
            {
                return this.formattingObject != null ? this.formattingObject.ToString() : "null";
            }
        }
    }
}