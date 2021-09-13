using System;

using R5T.T0036;

using R5T.T0045.X0001;


namespace System
{
    public static class IDocumentationLineExtensions
    {
        public static string EmptyExtensionsBaseImplementation(this IDocumentationLine _)
        {
            return DocumentationLines.EmptyExtensionsBaseImplementation;
        }

        public static string EmptyExtensionsBaseInterface(this IDocumentationLine _)
        {
            return DocumentationLines.EmptyExtensionsBaseInterface;
        }
    }
}
