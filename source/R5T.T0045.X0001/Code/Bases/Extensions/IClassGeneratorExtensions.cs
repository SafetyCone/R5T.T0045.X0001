using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0011.T004;
using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax GetT0027_T009Startup(this IClassGenerator _)
        {
            var constructor = Instances.MethodGenerator.GetT0027_T009StartupConstructor();

            var configureConfiguration = Instances.MethodGenerator.GetT0027_T009ConfigureConfiguration()
                .Indent(Instances.Indentation.Method())
                ;

            var configureServices = Instances.MethodGenerator.GetT0027_T009ConfigureServicesWithProvidedServices()
                .Indent(Instances.Indentation.Method())
                ;

            var output = _.GetPrivateClass(
                Instances.ClassName.Startup(),
                Instances.NamespacedTypeName.GetNamespacedName(
                    Instances.NamespaceName.Values().R5T_T0027_T009(),
                    Instances.ClassName.Startup()))
                .AddMembers(
                    constructor,
                    configureConfiguration,
                    configureServices)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetProgramAsAServiceProgram(this IClassGenerator _)
        {
            var mainMethodInMainRegion = Instances.MethodGenerator.GetProgramAsAServiceMain()
                .WrapWithRegion(
                    Instances.RegionName.Static(),
                    Instances.Indentation.Method())
                ;

            var serviceProviderProperty = Instances.PropertyGenerator.GetPrivateServiceProvider()
                .Indent(Instances.Indentation.Property())
                .Indent(Instances.Indentation.Property())
                .Indent(Instances.Indentation.Property())
                ;

            var constructor = Instances.MethodGenerator.GetProgramAsAServiceProgramConstructor()
                .Indent(Instances.Indentation.Method())
                .Indent(Instances.Indentation.Method())
                ;

            var serviceMain = Instances.MethodGenerator.GetProgramAsAServiceServiceMain()
                .Indent(Instances.Indentation.Method())
                ;

            var runOperation = Instances.MethodGenerator.GetProgramAsAServiceRunOperation()
                .Indent(Instances.Indentation.Method())
                ;

            var runMethod = Instances.MethodGenerator.GetProgramAsAServiceRunMethod()
                .Indent(Instances.Indentation.Method())
                ;

            var output = _.GetPrivateClass(
                Instances.ClassName.Program(),
                Instances.TypeName.ProgramAsAService())
                .AddMethod(mainMethodInMainRegion)
                .AddMembers(
                    serviceProviderProperty,
                    constructor,
                    serviceMain,
                    runOperation,
                    runMethod)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetDocumentationClass(this IClassGenerator _,
            string descriptionLine)
        {
            var documentationComment = Instances.DocumentationGenerator.GetClassDocumentationComment(descriptionLine);

            var output = _.GetPublicStaticClass(Instances.ClassName.Documentation())
                .AddDocumentation(documentationComment)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetServiceImplementation(this IClassGenerator _,
            string serviceImplementationNamespacedTypeName,
            string serviceDefinitionNamespacedTypeName,
            NamespaceNameSet namespaceNames)
        {
            var implementationTypeName = Instances.NamespacedTypeName.GetTypeName(serviceImplementationNamespacedTypeName);
            var definitionTypeName = Instances.NamespacedTypeName.GetTypeName(serviceDefinitionNamespacedTypeName);

            var output = _.GetPublicClass(
                implementationTypeName,
                definitionTypeName)
                .AddServiceImplementationMarkerAttribute(namespaceNames)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetIServiceCollectionExtensionsStub(this IClassGenerator _)
        {
            var output = _.GetPublicStaticClass(
                Instances.TypeName.IServiceCollectionExtensions());

            return output;
        }

        public static ClassDeclarationSyntax GetExtensionMethodBaseClass(this IClassGenerator _,
            string extensionMethodBaseClassTypeName,
            string extensionMethodBaseInterfaceTypeName)
        {
            var propertyIndentation = Instances.Indentation.Property();

            var instanceStaticProperty = Instances.PropertyGenerator.GetExtensionMethodBaseStaticInstance(extensionMethodBaseClassTypeName)
                .WrapWithRegion(Instances.RegionName.Static(), propertyIndentation)
                ;

            var output = _.GetPublicClass(extensionMethodBaseClassTypeName, extensionMethodBaseInterfaceTypeName)
                .AddDocumentation(Instances.DocumentationLine.EmptyExtensionsBaseImplementation())
                .AddMembers(instanceStaticProperty)
                ;

            return output;
        }
    }
}
