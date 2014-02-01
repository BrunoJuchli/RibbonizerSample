namespace Ribbonizer.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides several extension methods for reflection operations.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Returns the first custom attribute defined on this member, identified by <typeparamref name="TAttribute"/>,
        /// or <c>null</c> if there are no custom attributes of <typeparamref name="TAttribute"/> defined.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the custom attribute.</typeparam>
        /// <param name="provider">The provider on that the custom attribute is defined.</param>
        /// <returns>A instance of <typeparamref name="TAttribute"/> representing the first custom attribute, or <c>null</c>.</returns>
        /// <exception cref="TypeLoadException">The custom attribute type cannot be loaded.</exception>
        /// <extensiondoc category="Reflection" />
        public static TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider provider)
            where TAttribute : Attribute
        {
            return provider.GetCustomAttribute<TAttribute>(false);
        }

        /// <summary>
        /// Returns the first custom attribute defined on this member, identified by <typeparamref name="TAttribute"/>,
        /// or <c>null</c> if there are no custom attributes of <typeparamref name="TAttribute"/> defined.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the custom attribute.</typeparam>
        /// <param name="provider">The provider on that the custom attribute is defined.</param>
        /// <param name="inherit">If set to <c>true</c>, look up the hierarchy chain for the inherited custom attribute.</param>
        /// <returns>A instance of <typeparamref name="TAttribute"/> representing the first custom attribute, or <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="provider"/> parameter is <c>null</c>.</exception>
        /// <exception cref="TypeLoadException">The custom attribute type cannot be loaded.</exception>
        /// <extensiondoc category="Reflection" />
        public static TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            return provider.GetCustomAttributes(typeof(TAttribute), inherit).FirstOrDefault() as TAttribute;
        }

        /// <summary>
        /// Returns a sequence of custom attributes defined on this member, identified by <typeparamref name="TAttribute"/>,
        /// or an empty sequence if there are no custom attributes of <typeparamref name="TAttribute"/> defined.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the custom attributes.</typeparam>
        /// <param name="provider">The provider on that the custom attributes are defined.</param>
        /// <returns>A sequence of <typeparamref name="TAttribute"/> instances representing custom attributes, or an empty sequence.</returns>
        /// <exception cref="TypeLoadException">The custom attribute type cannot be loaded.</exception>
        /// <extensiondoc category="Reflection" />
        public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this ICustomAttributeProvider provider)
            where TAttribute : Attribute
        {
            return provider.GetCustomAttributes<TAttribute>(false);
        }

        /// <summary>
        /// Returns a sequence of custom attributes defined on this member, identified by <typeparamref name="TAttribute"/>,
        /// or an empty sequence if there are no custom attributes of <typeparamref name="TAttribute"/> defined.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the custom attributes.</typeparam>
        /// <param name="provider">The provider on that the custom attributes are defined.</param>
        /// <param name="inherit">If set to <c>true</c>, look up the hierarchy chain for the inherited custom attributes.</param>
        /// <returns>A sequence of <typeparamref name="TAttribute"/> instances representing custom attributes, or an empty sequence.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="provider"/> parameter is <c>null</c>.</exception>
        /// <exception cref="TypeLoadException">The custom attribute type cannot be loaded.</exception>
        /// <extensiondoc category="Reflection" />
        public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            return provider.GetCustomAttributes(typeof(TAttribute), inherit).Cast<TAttribute>();
        }
    }
}