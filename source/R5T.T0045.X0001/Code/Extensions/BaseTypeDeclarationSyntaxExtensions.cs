using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0011.T004;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class BaseTypeDeclarationSyntaxExtensions
    {
        public static T AddAttributeByAttributeName<T>(this T baseType,
            string attributeName)
            where T : BaseTypeDeclarationSyntax
        {
            var output = baseType.AddAttributeLists(Instances.SyntaxFactory.AttributeList()
                    .AddAttributes(Instances.SyntaxFactory.Attribute(attributeName))
                    .Indent(Instances.Indentation.TypeAttribute()))
                as T;

            return output;
        }

        public static T AddAttributeByAttributeNamespacedTypeName<T>(this T baseType,
            string attributeNamespacedTypeName,
            NamespaceNameSet namespaceNames)
            where T : BaseTypeDeclarationSyntax
        {
            var attributeNamespaceName = Instances.NamespacedTypeName.GetNamespaceName(attributeNamespacedTypeName);

            namespaceNames.Add(attributeNamespaceName);

            var attributeTypeName = Instances.NamespacedTypeName.GetTypeName(attributeNamespacedTypeName);

            var attributeName = Instances.AttributeTypeName.GetAttributeNameFromAttributeTypeName(attributeTypeName);

            var output = baseType.AddAttributeByAttributeName(attributeName);
            return output;
        }

        public static T AddAttribute<T>(this T baseType,
            string attributeNamespacedTypeName,
            NamespaceNameSet namespaceNames)
            where T : BaseTypeDeclarationSyntax
        {
            var output = baseType.AddAttributeByAttributeNamespacedTypeName(
                attributeNamespacedTypeName,
                namespaceNames);

            return output;
        }

        public static T AddDocumentation<T>(this T baseType,
            string documentationLineText)
            where T : BaseTypeDeclarationSyntax
        {
            var documentationComment = Instances.DocumentationGenerator.GetTypeDocumentationComment(documentationLineText);

            var output = baseType.AddDocumentation(documentationComment);
            return output;
        }

        public static T AddExtensionMethodBaseMarkerAttribute<T>(this T baseType,
            NamespaceNameSet namespaceNames)
            where T : BaseTypeDeclarationSyntax
        {
            var output = baseType.AddAttribute(
                Instances.NamespacedTypeName.ExtensionMethodBaseMarkerAttribute(),
                namespaceNames);

            return output;
        }

        public static T AddServiceDefinitionMarkerAttribute<T>(this T baseType,
            NamespaceNameSet namespaceNames)
            where T : BaseTypeDeclarationSyntax
        {
            var output = baseType.AddAttribute(
                Instances.NamespacedTypeName.ServiceDefinitionMarkerAttribute(),
                namespaceNames);

            return output;
        }

        public static T AddServiceImplementationMarkerAttribute<T>(this T baseType,
            NamespaceNameSet namespaceNames)
            where T : BaseTypeDeclarationSyntax
        {
            var output = baseType.AddAttribute(
                Instances.NamespacedTypeName.ServiceImplementationMarkerAttribute(),
                namespaceNames);

            return output;
        }
    }
}
