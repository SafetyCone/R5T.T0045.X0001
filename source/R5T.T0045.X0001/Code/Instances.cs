using System;

using R5T.T0035;
using R5T.T0036;


namespace R5T.T0045.X0001
{
    public static class Instances
    {
        public static IClassGenerator ClassGenerator { get; } = T0045.ClassGenerator.Instance;
        public static IClassName ClassName { get; } = T0036.ClassName.Instance;
        public static ICompilationUnitGenerator CompilationUnitGenerator { get; } = T0045.CompilationUnitGenerator.Instance;
        public static IDocumentationGenerator DocumentationGenerator { get; } = T0045.DocumentationGenerator.Instance;
        public static INamespaceName NamespaceName { get; } = T0035.NamespaceName.Instance;
    }
}
