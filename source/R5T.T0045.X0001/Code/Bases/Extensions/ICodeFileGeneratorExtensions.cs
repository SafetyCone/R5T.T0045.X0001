using System;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class ICodeFileGeneratorExtensions
    {
        public static void CreateT0027_T009Startup(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var startupCompilationUnit = Instances.CompilationUnitGenerator.GetT0027_T009Startup(namespaceName);

            startupCompilationUnit.WriteTo(filePath);
        }

        public static void CreateProgramAsAService(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var programAsAServiceCompilationUnit = Instances.CompilationUnitGenerator.GetProgramAsAServiceProgram(namespaceName);

            programAsAServiceCompilationUnit.WriteTo(filePath);
        }

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

        public static void CreateServiceDefinition(this ICodeFileGenerator _,
            string filePath,
            string serviceDefinitionNamespaceName,
            string serviceDefinitionInterfaceTypeName)
        {
            var serviceDefinitionInterfaceCompilationUnit = Instances.CompilationUnitGenerator.GetServiceDefinition(
                serviceDefinitionNamespaceName,
                serviceDefinitionInterfaceTypeName);

            serviceDefinitionInterfaceCompilationUnit.WriteTo(filePath);
        }

        public static void CreateServiceDefinition(this ICodeFileGenerator _,
            string filePath,
            string serviceDefinitionNamespacedTypeName)
        {
            var namespaceName = Instances.NamespacedTypeName.GetNamespaceName(serviceDefinitionNamespacedTypeName);
            var typeName = Instances.NamespacedTypeName.GetTypeName(serviceDefinitionNamespacedTypeName);

            _.CreateServiceDefinition(
                filePath,
                namespaceName,
                typeName);
        }

        public static void CreateServiceImplementation(this ICodeFileGenerator _,
            string filePath,
            string serviceImplementationNamespacedTypeName,
            string serviceDefinitionNamespacedTypeName)
        {
            var serviceDefinitionInterfaceCompilationUnit = Instances.CompilationUnitGenerator.GetServiceImplementation(
                serviceImplementationNamespacedTypeName,
                serviceDefinitionNamespacedTypeName);

            serviceDefinitionInterfaceCompilationUnit.WriteTo(filePath);
        }

        public static void CreateIServiceCollectionExtensionsStub(this ICodeFileGenerator _,
            string filePath,
            string serviceImplementationsNamespaceName)
        {
            var iServiceCollectionExtensionsCompilationUnit = Instances.CompilationUnitGenerator.GetIServiceCollectionExtensionsStub(
                serviceImplementationsNamespaceName);

            iServiceCollectionExtensionsCompilationUnit.WriteTo(filePath);
        }

        public static void CreateExtensionMethodBaseInterface(this ICodeFileGenerator _,
            string filePath,
            string extensionMethodBaseInterfaceNamespacedTypeName)
        {
            var baseExtensionMethodBaseCompilationUnit = Instances.CompilationUnitGenerator.GetExtensionMethodBaseInterface(
                extensionMethodBaseInterfaceNamespacedTypeName);

            baseExtensionMethodBaseCompilationUnit.WriteTo(filePath);
        }

        public static void CreateExtensionMethodBaseClass(this ICodeFileGenerator _,
            string filePath,
            string extensionMethodBaseClassNamespacedTypeName,
            string extensionMethodBaseInterfaceNamespacedTypeName)
        {
            var baseExtensionMethodBaseCompilationUnit = Instances.CompilationUnitGenerator.GetExtensionMethodBaseClass(
                extensionMethodBaseClassNamespacedTypeName,
                extensionMethodBaseInterfaceNamespacedTypeName);

            baseExtensionMethodBaseCompilationUnit.WriteTo(filePath);
        }
    }
}
