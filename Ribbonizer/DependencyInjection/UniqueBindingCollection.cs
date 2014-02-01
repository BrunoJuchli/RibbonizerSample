namespace Ribbonizer.DependencyInjection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    internal class UniqueBindingCollection<T> : IUniqueBindingCollection<T>
    {
        private readonly IEnumerable<T> enumerable;

        public UniqueBindingCollection(IEnumerable<T> source)
        {
            this.enumerable = source.ToList();
            EnsureItemsAreDistinct(this.enumerable);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.enumerable.GetEnumerator();
        }

        private static void EnsureItemsAreDistinct(IEnumerable<T> items)
        {
            const string ItemTypeSpecificMessage = "{0} Bindings for {1}";

            var violatingProviderTypeNames = items
                .GroupBy(x => x.GetType())
                .Where(x => x.Count() > 1)
                .Select(x => string.Format(CultureInfo.InvariantCulture, ItemTypeSpecificMessage, x.Count(), x.Key.FullName))
                .ToList();

            if (violatingProviderTypeNames.Any())
            {
                const string Message = "The following {0} have more than one ninject binding:";
                var builder = new StringBuilder();
                builder.AppendLine(string.Format(CultureInfo.InvariantCulture, Message, typeof(T).Name));
                violatingProviderTypeNames.ForEach(typeName => builder.AppendLine(typeName));

                throw new NotSupportedException(builder.ToString());
            }
        }
    }
}