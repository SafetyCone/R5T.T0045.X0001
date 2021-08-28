using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class ICompilationUnitGeneratorExtensions
    {
        public static CompilationUnitSyntax GetDocumentation(this ICompilationUnitGenerator _,
            string namespaceName,
            string documentationLine)
        {
            var output = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    var defaultProgramClass = Instances.ClassGenerator.GetDocumentationClass(documentationLine);

                    var outputNamespace = xNamespace.AddClass(defaultProgramClass);
                    return outputNamespace;
                });

            return output;
        }
    }
}
