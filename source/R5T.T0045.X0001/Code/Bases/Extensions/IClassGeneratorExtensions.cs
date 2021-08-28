using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax GetDocumentationClass(this IClassGenerator _,
            string descriptionLine)
        {
            var documentationComment = Instances.DocumentationGenerator.GetClassDocumentationComment(descriptionLine);

            var output = _.GetPublicStaticClass(Instances.ClassName.Documentation())
                .AddDocumentation(documentationComment)
                ;

            return output;
        }
    }
}
