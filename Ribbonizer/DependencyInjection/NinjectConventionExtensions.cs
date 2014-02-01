namespace Ribbonizer.DependencyInjection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ninject.Extensions.Conventions.BindingBuilder;
    using Ninject.Extensions.Conventions.Syntax;
    using Ninject.Modules;

    public static class NinjectConventionExtensions
    {
        private const string ScanPattern = "Ribbonizer*";

        private const string TestAssemblySuffix = "Test.dll";
        private const string SpecificationsAssemblySuffix = "Specifications.dll";

        public static IIncludingNonePublicTypesSelectSyntax FromProductionAssemblies(this IFromSyntax syntax)
        {
            using (var assemblyNameRetriever = new AssemblyNameRetriever())
            {
                var assemblyFinder = new AssemblyFinder(assemblyNameRetriever);

                IEnumerable<string> assemblyFileNames = assemblyFinder
                    .FindAssembliesMatching(new[] { ScanPattern })
                    .Where(assemblyFileName => IsProductionAssembly(assemblyFileName));

                return syntax.From(assemblyFileNames);
            }
        }

        public static IConfigureSyntax BindTo<T>(this IBindSyntax syntax)
        {
            var types = new[] { typeof(T) };
            return syntax.BindSelection((type, baseTypes) => types);
        }

        private static bool IsProductionAssembly(string assemblyFileName)
        {
            return !assemblyFileName.EndsWith(TestAssemblySuffix, StringComparison.OrdinalIgnoreCase)
                && !assemblyFileName.EndsWith(SpecificationsAssemblySuffix, StringComparison.OrdinalIgnoreCase);
        }
    }
}