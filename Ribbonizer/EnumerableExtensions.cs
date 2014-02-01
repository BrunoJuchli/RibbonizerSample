namespace Ribbonizer
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// Provides a set of extension methods for objects that implement <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        private const int NextCount = 1;

        /// <summary>
        /// Creates a <see cref="Collection{T}"/> from an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="Collection{T}"/> from.</param>
        /// <returns>A <see cref="Collection{T}"/> that contains items from the input sequence.</returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="source"/> parameter is <c>null</c>.</exception>
        /// <extensiondoc category="Enumerable" />
        public static Collection<T> ToCollection<T>(this IEnumerable<T> source)
        {
            return new Collection<T>(source.ToList());
        }

        public static ICollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            // replace return type by IReadOnlyCollection as soon as we migrate to .net 4.5
            return new ReadOnlyCollection<T>(source.ToList());
        }

        /// <summary>
        /// Performs the specified action on each element of the <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <param name="source">The source enumerable to execute the action for.</param>
        /// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the <see cref="IEnumerable{T}"/>.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="source"/> parameter is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="action"/> parameter is <c>null</c>.</exception>
        /// <extensiondoc category="Enumerable" />
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performs the specified action on each element of the <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <typeparam name="TException">The type of exception which is aggregated.</typeparam>
        /// <param name="source">The source enumerable to execute the action for.</param>
        /// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the <see cref="IEnumerable{T}"/>.</param>
        /// <exception cref="AggregateException">The <paramref name="action"/> throws an exception of <typeparamref name="TException"/> for one or more items.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="source"/> parameter is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="action"/> parameter is <c>null</c>.</exception>
        /// <extensiondoc category="Enumerable" />
        public static void ForEachAggregateExceptions<T, TException>(this IEnumerable<T> source, Action<T> action)
            where TException : Exception
        {
            var exceptions = new List<TException>();

            foreach (T item in source)
            {
                try
                {
                    action(item);
                }
                catch (TException exception)
                {
                    exceptions.Add(exception);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
        {
            return source.Concat(new[] { item });
        }

        /// <summary>
        /// Gets the next element of the current <see cref="IEnumerable{T}"/> followed by the item that matches the specified <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <param name="source">The source enumerable to get the next element from.</param>
        /// <param name="predicate">The predicate that matches the item to get the next item for.</param>
        /// <returns>The next element of the current <see cref="IEnumerable{T}"/> followed by the item that matches the specified <paramref name="predicate"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="source"/> parameter is <c>null</c>.</exception>
        /// <extensiondoc category="Enumerable" />
        public static T Next<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.SkipWhile(predicate).Next();
        }

        /// <summary>
        /// Gets the next element of the current <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <param name="source">The source enumerable to get the next element from.</param>
        /// <returns>The next element of the current <see cref="IEnumerable{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="source"/> parameter is <c>null</c>.</exception>
        /// <extensiondoc category="Enumerable" />
        public static T Next<T>(this IEnumerable<T> source)
        {
            return source.Skip(NextCount).FirstOrDefault();
        }

        public static IEnumerable<T> Repeat<T>(Func<T> factoryAction, int count)
        {
            return Enumerable.Repeat(factoryAction, count)
                .Select(factory => factory());
        }

        public static void RemoveAll<T>(this Collection<T> collection, Func<T, bool> matcher)
        {
            collection
                .Where(x => matcher(x)).ToCollection()
                .ForEach(x => collection.Remove(x));
        }

        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    
        public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
        {
            return source
                .Select(selector)
                .Aggregate(TimeSpan.Zero, (current, next) => current + next);
        }
    }
}
