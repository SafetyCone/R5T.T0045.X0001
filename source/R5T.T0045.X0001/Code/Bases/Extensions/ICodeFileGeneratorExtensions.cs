using System;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class ICodeFileGeneratorExtensions
    {
        public static void CreateDocumentation(this ICodeFileGenerator _,
            string filePath,
            string namespaceName,
            string documentationLine)
        {
            var documentationCompilationUnit = Instances.CompilationUnitGenerator.GetDocumentation(
                namespaceName,
                documentationLine);

            documentationCompilationUnit.WriteTo(filePath);
        }
    }
}
