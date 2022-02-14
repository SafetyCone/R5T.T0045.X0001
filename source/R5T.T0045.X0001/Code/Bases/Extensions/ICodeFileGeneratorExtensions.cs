using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            startupCompilationUnit.WriteToSynchronous(filePath);
        }

        public static async Task CreateProgramAsAService(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var programCompilationUnit = Instances.CompilationUnitGenerator.NewCompilationUnit();

            programCompilationUnit = await Instances.CompilationUnitOperator.ModifyProgramAsAService_Initial(programCompilationUnit, namespaceName);
            programCompilationUnit = await Instances.CompilationUnitOperator.ModifyProgramAsAService_AddSerializeConfigurationAudit(programCompilationUnit);
            programCompilationUnit = await Instances.CompilationUnitOperator.ModifyProgramAsAService_AddSerializeServiceCollectionAudit(programCompilationUnit);

            await programCompilationUnit.WriteTo(filePath);
        }

        public static void CreateProgramAsAService_Old(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var programAsAServiceCompilationUnit = Instances.CompilationUnitGenerator.GetProgramAsAServiceProgram_Old(namespaceName);

            programAsAServiceCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateDocumentation(this ICodeFileGenerator _,
            string filePath,
            string namespaceName,
            string documentationLine)
        {
            var documentationCompilationUnit = Instances.CompilationUnitGenerator.GetDocumentation(
                namespaceName,
                documentationLine);

            documentationCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateServiceDefinition(this ICodeFileGenerator _,
            string filePath,
            string serviceDefinitionNamespaceName,
            string serviceDefinitionInterfaceTypeName)
        {
            var serviceDefinitionInterfaceCompilationUnit = Instances.CompilationUnitGenerator.GetServiceDefinition(
                serviceDefinitionNamespaceName,
                serviceDefinitionInterfaceTypeName);

            serviceDefinitionInterfaceCompilationUnit.WriteToSynchronous(filePath);
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

            serviceDefinitionInterfaceCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateIServiceAggregationStub(this ICodeFileGenerator _,
            string filePath,
            string namespaceName,
            string iServiceAggregationIncrementInterfaceNamespacedTypeName)
        {
            var iServiceAggregationStubCompilationUnit = Instances.CompilationUnitGenerator.GetIServiceAggregationInterfaceStub(
                namespaceName,
                iServiceAggregationIncrementInterfaceNamespacedTypeName);

            iServiceAggregationStubCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateIServiceAggregationStub(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var iServiceAggregationIncrementInterfaceNamespacedTypeName = Instances.NamespacedTypeName.IServicesAggregationIncrement(namespaceName);

            _.CreateIServiceAggregationStub(
                filePath,
                namespaceName,
                iServiceAggregationIncrementInterfaceNamespacedTypeName);
        }

        public static void CreateIServiceAggregationIncrementStub(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var iServiceAggregationIncrementStubCompilationUnit = Instances.CompilationUnitGenerator.GetIServiceAggregationIncrementStub(
                namespaceName);

            iServiceAggregationIncrementStubCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateIServiceCollectionExtensionsStub(this ICodeFileGenerator _,
            string filePath,
            string serviceImplementationsNamespaceName)
        {
            var iServiceCollectionExtensionsCompilationUnit = Instances.CompilationUnitGenerator.GetIServiceCollectionExtensionsStub(
                serviceImplementationsNamespaceName);

            iServiceCollectionExtensionsCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateExtensionMethodBaseInterface(this ICodeFileGenerator _,
            string filePath,
            string extensionMethodBaseInterfaceNamespacedTypeName)
        {
            var baseExtensionMethodBaseCompilationUnit = Instances.CompilationUnitGenerator.GetExtensionMethodBaseInterface(
                extensionMethodBaseInterfaceNamespacedTypeName);

            baseExtensionMethodBaseCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateIServiceAggregationExtensionsClassStub(this ICodeFileGenerator _,
            string filePath,
            string iServiceAggregationInterfaceNamespacedTypeName)
        {
            var iServiceAggregationExtensionsStubCompilationUnit = Instances.CompilationUnitGenerator.GetIServiceAggregationExtensionsStub(
                iServiceAggregationInterfaceNamespacedTypeName);

            iServiceAggregationExtensionsStubCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateIServiceAggregationIncrementExtensionsClassStub(this ICodeFileGenerator _,
            string filePath,
            string iServiceAggregationIncrementInterfaceNamespacedTypeName)
        {
            var iServiceAggregationIncrementExtensionsStubCompilationUnit = Instances.CompilationUnitGenerator.GetIServiceAggregationIncrementExtensionsStub(
                iServiceAggregationIncrementInterfaceNamespacedTypeName);

            iServiceAggregationIncrementExtensionsStubCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateServiceAggregationClassStub(this ICodeFileGenerator _,
            string filePath,
            string namespaceName,
            string iServiceAggregationInterfaceNamespacedTypeName)
        {
            var serviceAggregationClassCompilationUnit = Instances.CompilationUnitGenerator.GetServiceAggregationClassStub(
                namespaceName,
                iServiceAggregationInterfaceNamespacedTypeName);

            serviceAggregationClassCompilationUnit.WriteToSynchronous(filePath);
        }

        public static void CreateServiceAggregationClassStub(this ICodeFileGenerator _,
            string filePath,
            string namespaceName)
        {
            var iServiceAggregationInterfaceNamespacedTypeName = Instances.NamespacedTypeName.IServiceAggregation(namespaceName);

            _.CreateServiceAggregationClassStub(
                filePath,
                namespaceName,
                iServiceAggregationInterfaceNamespacedTypeName);
        }

        public static void CreateExtensionMethodBaseClass(this ICodeFileGenerator _,
            string filePath,
            string extensionMethodBaseClassNamespacedTypeName,
            string extensionMethodBaseInterfaceNamespacedTypeName)
        {
            var baseExtensionMethodBaseCompilationUnit = Instances.CompilationUnitGenerator.GetExtensionMethodBaseClass(
                extensionMethodBaseClassNamespacedTypeName,
                extensionMethodBaseInterfaceNamespacedTypeName);

            baseExtensionMethodBaseCompilationUnit.WriteToSynchronous(filePath);
        }
    }
}
