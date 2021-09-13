using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class ICompilationUnitGeneratorExtensions
    {
        public static CompilationUnitSyntax GetT0027_T009Startup(this ICompilationUnitGenerator _,
            string namespaceName)
        {
            var output = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    var namespaceNameValues = Instances.NamespaceName.Values();
                    xNamespaceNames.AddRange(
                        namespaceNameValues.System_Threading_Tasks(),
                        namespaceNameValues.Microsoft_Extensions_Configuration(),
                        namespaceNameValues.Microsoft_Extensions_DependencyInjection(),
                        namespaceNameValues.Microsoft_Extensions_Logging(),
                        namespaceNameValues.R5T_Dacia(),
                        namespaceNameValues.R5T_T0027_T008());

                    var startupClass = Instances.ClassGenerator.GetT0027_T009Startup();

                    var outputNamespace = xNamespace.AddClass(startupClass);
                    return outputNamespace;
                });

            return output;
        }

        public static CompilationUnitSyntax GetProgramAsAServiceProgram(this ICompilationUnitGenerator _,
            string namespaceName)
        {
            var output = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    var namespaceNameValues = Instances.NamespaceName.Values();
                    xNamespaceNames.AddRange(
                        namespaceNameValues.System_Threading(),
                        namespaceNameValues.System_Threading_Tasks(),
                        namespaceNameValues.Microsoft_Extensions_Hosting(),
                        namespaceNameValues.R5T_Plymouth(),
                        namespaceNameValues.R5T_Plymouth_ProgramAsAService());

                    var programAsAServiceClass = Instances.ClassGenerator.GetProgramAsAServiceProgram();

                    var outputNamespace = xNamespace.AddClass(programAsAServiceClass);
                    return outputNamespace;
                });

            return output;
        }

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

        public static CompilationUnitSyntax GetServiceDefinition(this ICompilationUnitGenerator _,
            string serviceDefinitionNamespaceName,
            string serviceDefinitionInterfaceTypeName)
        {
            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                serviceDefinitionNamespaceName,
                (@namespace, namespaceNames) =>
                {
                    namespaceNames.Add(Instances.NamespaceName.System().Threading().Tasks().Value());

                    var serviceDefinitionInterface = Instances.InterfaceGenerator.GetServiceDefinition(
                        serviceDefinitionInterfaceTypeName,
                        namespaceNames);

                    var namespaceOutput = @namespace.AddInterface(serviceDefinitionInterface);
                    return namespaceOutput;
                });

            return output;
        }

        public static CompilationUnitSyntax GetServiceImplementation(this ICompilationUnitGenerator _,
            string serviceImplementationNamespacedTypeName,
            string serviceDefinitionNamespacedTypeName)
        {
            var implementationNamespaceName = Instances.NamespacedTypeName.GetNamespaceName(serviceImplementationNamespacedTypeName);
            var definitionNamespaceName = Instances.NamespacedTypeName.GetNamespaceName(serviceDefinitionNamespacedTypeName);

            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                implementationNamespaceName,
                (@namespace, namespaceNames) =>
                {
                    namespaceNames.AddRange(
                        Instances.NamespaceName.System().Threading().Tasks().Value(),
                        definitionNamespaceName);

                    var serviceImplementationClass = Instances.ClassGenerator.GetServiceImplementation(
                        serviceImplementationNamespacedTypeName,
                        serviceDefinitionNamespacedTypeName,
                        namespaceNames);

                    var namespaceOutput = @namespace.AddClass(serviceImplementationClass);
                    return namespaceOutput;
                });

            return output;
        }

        public static CompilationUnitSyntax GetIServiceCollectionExtensionsStub(this ICompilationUnitGenerator _,
            string serviceImplementationsNamespaceName)
        {
            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                serviceImplementationsNamespaceName,
                (@namespace, namespaceNames) =>
                {
                    namespaceNames.AddRange(
                        Instances.NamespaceName.Microsoft().Extensions().DependencyInjection().Value(),
                        Instances.NamespaceName.R5T().Dacia().Value());

                    var iServiceCollectionExtensionsStubClass = Instances.ClassGenerator.GetIServiceCollectionExtensionsStub();

                    var namespaceOutput = @namespace.AddClass(iServiceCollectionExtensionsStubClass);
                    return namespaceOutput;
                });

            return output;
        }

        public static CompilationUnitSyntax GetExtensionMethodBaseInterface(this ICompilationUnitGenerator _,
            string extensionMethodBaseInterfaceNamespacedTypeName)
        {
            var namespaceName = Instances.NamespacedTypeName.GetNamespaceName(extensionMethodBaseInterfaceNamespacedTypeName);
            var typeName = Instances.NamespacedTypeName.GetTypeName(extensionMethodBaseInterfaceNamespacedTypeName);

            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                namespaceName,
                (@namespace, namespaceNames) =>
                {
                    var extensionMethodBaseInterface = Instances.InterfaceGenerator.GetExtensionMethodBase(
                        typeName,
                        namespaceNames);

                    var namespaceOutput = @namespace.AddInterface(extensionMethodBaseInterface);
                    return namespaceOutput;
                });

            return output;
        }

        public static CompilationUnitSyntax GetExtensionMethodBaseClass(this ICompilationUnitGenerator _,
            string extensionMethodBaseClassNamespacedTypeName,
            string extensionMethodBaseInterfaceNamespacedTypeName)
        {
            var implementationNamespaceName = Instances.NamespacedTypeName.GetNamespaceName(extensionMethodBaseClassNamespacedTypeName);
            var implementationTypeName = Instances.NamespacedTypeName.GetTypeName(extensionMethodBaseClassNamespacedTypeName);

            var interfaceNamespaceName = Instances.NamespacedTypeName.GetNamespaceName(extensionMethodBaseInterfaceNamespacedTypeName);
            var interfaceTypeName = Instances.NamespacedTypeName.GetTypeName(extensionMethodBaseInterfaceNamespacedTypeName);

            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                implementationNamespaceName,
                (@namespace, namespaceNames) =>
                {
                    if(interfaceNamespaceName != implementationNamespaceName)
                    {
                        namespaceNames.Add(interfaceNamespaceName);
                    }

                    var extensionMethodBaseInterface = Instances.ClassGenerator.GetExtensionMethodBaseClass(
                        implementationTypeName,
                        interfaceTypeName);

                    var namespaceOutput = @namespace.AddClass(extensionMethodBaseInterface);
                    return namespaceOutput;
                });

            return output;
        }
    }
}
