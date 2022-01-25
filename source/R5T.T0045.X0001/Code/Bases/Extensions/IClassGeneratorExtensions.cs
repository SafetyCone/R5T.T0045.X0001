using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0011.T004;
using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class IClassGeneratorExtensions
    {
        public static ClassDeclarationSyntax CreateInstances(this IClassGenerator _,
            IEnumerable<(string ExtensionMethodBaseInterfaceTypeName, string PropertyName, string InitializationExpression)> instanceTuples = default)
        {
            var properties = instanceTuples is object
                ? instanceTuples
                    .OrderAlphabetically(xTuple => xTuple.ExtensionMethodBaseInterfaceTypeName)
                    .Select(xTuple => Instances.PropertyGenerator.GetInstancesInstanceProperty(
                        xTuple.ExtensionMethodBaseInterfaceTypeName,
                        xTuple.PropertyName,
                        xTuple.InitializationExpression)
                        .Indent(Instances.Indentation.Property()))
                    .Now()
                : Array.Empty<PropertyDeclarationSyntax>()
                ;

            var output = _.GetPublicStaticClass(Instances.ClassName.Instances())
                .AddMembers(properties)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetT0027_T009Startup(this IClassGenerator _,
            string codeBodyNamespaceName)
        {
            var constructor = Instances.MethodGenerator.GetT0027_T009StartupConstructor();

            var configureConfiguration = Instances.MethodGenerator.GetT0027_T009ConfigureConfiguration()
                .Indent(Instances.Indentation.Method())
                ;

            var configureServices = Instances.MethodGenerator.GetT0027_T009ConfigureServicesWithProvidedServices()
                .Indent(Instances.Indentation.Method())
                ;

            var baseStartupNamespacedTypeName = Instances.NamespacedTypeName.Startup_R5T_T0027_T009();
            var baseClassRelativeNamespacedTypeName = Instances.NamespacedTypeName.GetRelativeNamespacedTypeName(
                baseStartupNamespacedTypeName,
                codeBodyNamespaceName);

            var output = _.GetPrivateClass(
                Instances.ClassName.Startup(),
                baseClassRelativeNamespacedTypeName)
                .AddMembers(
                    constructor,
                    configureConfiguration,
                    configureServices)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetT0027_T009Startup(this IClassGenerator _)
        {
            var defaultNamespaceName = Instances.NamespaceName.Values()._Default();

            var output = _.GetT0027_T009Startup(defaultNamespaceName);
            return output;
        }

        public static ClassDeclarationSyntax GetProgramAsAServiceProgram(this IClassGenerator _,
            string namespaceName)
        {
            var mainMethodInMainRegion = Instances.MethodGenerator.GetProgramAsAServiceMain(
                namespaceName)
                .WrapWithRegion(
                    Instances.RegionName.Static(),
                    Instances.Indentation.Method())
                ;

            var constructor = Instances.MethodGenerator.GetProgramAsAServiceProgramConstructor();
            var runMethod = Instances.MethodGenerator.GetProgramAsAServiceRunMethodMethod();
            var runOperation = Instances.MethodGenerator.GetProgramAsAServiceRunOperationMethod();
            var serviceMain = Instances.MethodGenerator.GetProgramAsAServiceServiceMain();

            var output = _.GetPrivateClass(
                Instances.ClassName.Program(),
                Instances.TypeName.ProgramAsAServiceBase())
                .AddMethod(mainMethodInMainRegion)
                .AddMethods(
                    constructor,
                    serviceMain,
                    runOperation,
                    runMethod)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetProgramAsAServiceProgram_Old(this IClassGenerator _)
        {
            var mainMethodInMainRegion = Instances.MethodGenerator.GetProgramAsAServiceMain_Old()
                .WrapWithRegion(
                    Instances.RegionName.Static(),
                    Instances.Indentation.Method())
                ;

            var serviceProviderProperty = Instances.PropertyGenerator.GetPrivateServiceProvider()
                .Indent(Instances.Indentation.Property())
                .Indent(Instances.Indentation.Property())
                .Indent(Instances.Indentation.Property())
                ;

            var constructor = Instances.MethodGenerator.GetProgramAsAServiceProgramConstructor_Old()
                .Indent(Instances.Indentation.Method())
                .Indent(Instances.Indentation.Method())
                ;

            var serviceMain = Instances.MethodGenerator.GetProgramAsAServiceServiceMain()
                .Indent(Instances.Indentation.Method())
                ;

            var runOperation = Instances.MethodGenerator.GetProgramAsAServiceRunOperationMethod()
                .Indent(Instances.Indentation.Method())
                ;

            var runMethod = Instances.MethodGenerator.GetProgramAsAServiceRunMethodMethod()
                .Indent(Instances.Indentation.Method())
                ;

            var output = _.GetPrivateClass(
                Instances.ClassName.Program(),
                Instances.TypeName.ProgramAsAServiceBase())
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

        public static ClassDeclarationSyntax GetDocumentation(this IClassGenerator _,
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

        public static ClassDeclarationSyntax GetExtensionMethodBase(this IClassGenerator _,
            string extensionMethodBaseClassTypeName,
            string extensionMethodBaseInterfaceTypeName)
        {
            var propertyIndentation = Instances.Indentation.Property();

            var instanceStaticProperty = Instances.PropertyGenerator.GetExtensionMethodBaseStaticInstance(extensionMethodBaseClassTypeName)
                .Indent(propertyIndentation)
                .WrapWithRegion(Instances.RegionName.Static(), propertyIndentation)
                ;

            var output = _.GetPublicClass(extensionMethodBaseClassTypeName, extensionMethodBaseInterfaceTypeName)
                .AddDocumentation(Instances.DocumentationLine.EmptyExtensionsBaseImplementation())
                .AddMembers(instanceStaticProperty)
                ;

            return output;
        }

        public static ClassDeclarationSyntax GetServiceAggregationStub(this IClassGenerator _,
            string iServiceAggregationRelativeNamespacedTypeName)
        {
            var output = _.GetPublicClass(
                Instances.ClassName.ServiceAggregation(),
                iServiceAggregationRelativeNamespacedTypeName);

            return output;
        }

        public static ClassDeclarationSyntax GetIServiceAggregationExtensionsClassStub(this IClassGenerator _,
            string iServiceAggregationIncrementInterfaceTypeName)
        {
            var fillFromMethod = Instances.MethodGenerator.GetFillFromMethod(iServiceAggregationIncrementInterfaceTypeName);

            var iServiceAggregationIncrementExtensionsClass = _.GetPublicStaticClass(Instances.ClassName.IServiceAggregationExtensions())
                .AddMembers(fillFromMethod)
                ;

            return iServiceAggregationIncrementExtensionsClass;
        }

        public static ClassDeclarationSyntax GetIServiceAggregationIncrementExtensionsClassStub(this IClassGenerator _,
            string iServiceAggregationIncrementInterfaceTypeName)
        {
            var fillFromMethod = Instances.MethodGenerator.GetFillFromMethod(iServiceAggregationIncrementInterfaceTypeName);

            var iServiceAggregationIncrementExtensionsClass = _.GetPublicStaticClass(Instances.ClassName.IServiceAggregationIncrementExtensions())
                .AddMembers(fillFromMethod)
                ;

            return iServiceAggregationIncrementExtensionsClass;
        }
    }
}
