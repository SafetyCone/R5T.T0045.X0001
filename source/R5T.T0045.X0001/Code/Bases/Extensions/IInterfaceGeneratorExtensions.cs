using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0011.T004;
using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class IInterfaceGeneratorExtensions
    {
        public static InterfaceDeclarationSyntax GetServiceDefinition(this IInterfaceGenerator _,
            string serviceDefinitionInterfaceTypeName,
            NamespaceNameSet namespaceNames)
        {
            var output = _.GetPublicInterface(serviceDefinitionInterfaceTypeName)
                .AddServiceDefinitionMarkerAttribute(namespaceNames)
                ;

            return output;
        }

        public static InterfaceDeclarationSyntax GetExtensionMethodBase(this IInterfaceGenerator _,
            string extensionMethodBaseClassTypeName,
            NamespaceNameSet namespaceNames)
        {
            var output = _.GetPublicInterface(extensionMethodBaseClassTypeName)
                .AddExtensionMethodBaseMarkerAttribute(namespaceNames)
                .AddDocumentation(Instances.DocumentationLine.EmptyExtensionsBaseInterface())
                ;

            return output;
        }
    }
}
