using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class ICompilationUnitGeneratorExtensions
    {
        public static CompilationUnitSyntax CreateInstances(this ICompilationUnitGenerator _,
            string namespaceName,
            IEnumerable<string> extensionMethodBaseInterfaceNamespacedTypeNames = default)
        {
            var distinctExtensionMethodBaseInterfaceNamespacedTypeNames = extensionMethodBaseInterfaceNamespacedTypeNames
                .Distinct()
                ;

            // Get namespaces.
            var extensionMethodBaseNamespaceNames = distinctExtensionMethodBaseInterfaceNamespacedTypeNames
                .Select(x => Instances.NamespacedTypeName.GetNamespaceName(x))
                .OrderAlphabetically()
                .Now();

            // Compute instance tuples.
            var instanceTuples = distinctExtensionMethodBaseInterfaceNamespacedTypeNames
                .Select(x =>
                {
                    var namespaceName = Instances.NamespacedTypeName.GetNamespaceName(x);
                    var interfaceTypeName = Instances.NamespacedTypeName.GetTypeName(x);
                    var typeName = Instances.TypeName.GetTypeNameStemFromInterfaceName(interfaceTypeName);
                    var namespacedTypeName = Instances.NamespacedTypeName.GetNamespacedName(
                        namespaceName,
                        typeName);

                    var relativeNamespaceName = Instances.NamespacedTypeName.GetRelativeNamespacedTypeName(
                        namespacedTypeName,
                        namespaceName);

                    var initializationExpression = $"{relativeNamespaceName}.{Instances.PropertyName.Instance()}";

                    var propertyName = typeName;

                    return (interfaceTypeName, propertyName, initializationExpression);
                })
                .Now();

            var output = _.InNewNamespace(
                namespaceName,
                (xNamespace, xNamespaceNames) =>
                {
                    // System namespace already added.
                    xNamespaceNames.AddRange(extensionMethodBaseNamespaceNames);

                    var instancesClass = Instances.ClassGenerator.CreateInstances(instanceTuples);

                    var outputNamespace = xNamespace.AddClass(instancesClass);
                    return outputNamespace;
                });

            return output;
        }

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

                    var startupClass = Instances.ClassGenerator.GetT0027_T009Startup(namespaceName);

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
                        namespaceNameValues.R5T_D0088(),
                        namespaceNameValues.R5T_D0090());

                    var programAsAServiceClass = Instances.ClassGenerator.GetProgramAsAServiceProgram();

                    var outputNamespace = xNamespace.AddClass(programAsAServiceClass);
                    return outputNamespace;
                });

            return output;
        }

        public static CompilationUnitSyntax GetProgramAsAServiceProgram_Old(this ICompilationUnitGenerator _,
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

                    var programAsAServiceClass = Instances.ClassGenerator.GetProgramAsAServiceProgram_Old();

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
                    var defaultProgramClass = Instances.ClassGenerator.GetDocumentation(documentationLine);

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
                        Instances.NamespaceName.Values().System_Threading_Tasks());

                    namespaceNames.AddNamespacedTypeName(
                        implementationNamespaceName,
                        serviceDefinitionNamespacedTypeName);

                    var serviceImplementationClass = Instances.ClassGenerator.GetServiceImplementation(
                        serviceImplementationNamespacedTypeName,
                        serviceDefinitionNamespacedTypeName,
                        namespaceNames);

                    var namespaceOutput = @namespace.AddClass(serviceImplementationClass);
                    return namespaceOutput;
                });

            return output;
        }

        public static CompilationUnitSyntax GetServiceAggregationClassStub(this ICompilationUnitGenerator _,
            string namespaceName,
            string iServiceAggregationInterfaceNamespacedTypeName)
        {
            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                namespaceName,
                (@namespace, namespaceNames) =>
                {
                    namespaceNames.AddRange(
                        Instances.NamespaceName.Values().R5T_Dacia());

                    namespaceNames.AddNamespacedTypeName(
                        namespaceName,
                        iServiceAggregationInterfaceNamespacedTypeName);

                    var iServiceAggregationRelativeNamespacedTypeName = Instances.NamespacedTypeName.GetRelativeNamespacedTypeNameOld(
                        iServiceAggregationInterfaceNamespacedTypeName,
                        namespaceName);

                    var iServiceAggregationStubInterface = Instances.ClassGenerator.GetServiceAggregationStub(
                        iServiceAggregationRelativeNamespacedTypeName);

                    var namespaceOutput = @namespace.AddClass(iServiceAggregationStubInterface);
                    return namespaceOutput;
                });

            return output;
        }

        public static CompilationUnitSyntax GetIServiceAggregationInterfaceStub(this ICompilationUnitGenerator _,
            string namespaceName,
            string iServiceAggregationIncrementNamespacedTypeName)
        {
            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                namespaceName,
                (@namespace, namespaceNames) =>
                {
                    namespaceNames.AddRange(
                        Instances.NamespaceName.Values().R5T_Dacia());

                    namespaceNames.AddNamespacedTypeName(
                        namespaceName,
                        iServiceAggregationIncrementNamespacedTypeName);

                    var iServiceAggregationIncrementRelativeNamespacedTypeName = Instances.NamespacedTypeName.GetRelativeNamespacedTypeNameOld(
                        iServiceAggregationIncrementNamespacedTypeName,
                        namespaceName);

                    var iServiceAggregationStubInterface = Instances.InterfaceGenerator.GetIServiceAggregationStub(
                        iServiceAggregationIncrementRelativeNamespacedTypeName);

                    var namespaceOutput = @namespace.AddInterface(iServiceAggregationStubInterface);
                    return namespaceOutput;
                });

            return output;
        }

        public static CompilationUnitSyntax GetIServiceAggregationExtensionsStub(this ICompilationUnitGenerator _,
            string iServiceAggregationInterfaceNamespacedTypeName)
        {
            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                Instances.NamespaceName.Values().System(), // Use the System namespace for these extensions.
                (@namespace, namespaceNames) =>
                {
                    var iServiceAggregationInterfaceNamespaceName = Instances.NamespacedTypeName.GetNamespaceName(iServiceAggregationInterfaceNamespacedTypeName);
                    var iServiceAggregationInterfaceTypeName = Instances.NamespacedTypeName.GetTypeName(iServiceAggregationInterfaceNamespacedTypeName);

                    namespaceNames.AddRange(iServiceAggregationInterfaceNamespaceName);

                    var iServiceAggregationExtensionsStubClass = Instances.ClassGenerator.GetIServiceAggregationExtensionsClassStub(
                        iServiceAggregationInterfaceTypeName);

                    var namespaceOutput = @namespace.AddClass(iServiceAggregationExtensionsStubClass);
                    return namespaceOutput;
                });

            return output;
        }

        public static CompilationUnitSyntax GetIServiceAggregationIncrementExtensionsStub(this ICompilationUnitGenerator _,
            string iServiceAggregationIncrementInterfaceNamespacedTypeName)
        {
            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                Instances.NamespaceName.Values().System(), // Use the System namespace for these extensions.
                (@namespace, namespaceNames) =>
                {
                    var iServiceAggregationIncrementInterfaceNamespaceName = Instances.NamespacedTypeName.GetNamespaceName(iServiceAggregationIncrementInterfaceNamespacedTypeName);
                    var iServiceAggregationIncrementInterfaceTypeName = Instances.NamespacedTypeName.GetTypeName(iServiceAggregationIncrementInterfaceNamespacedTypeName);

                    namespaceNames.AddRange(iServiceAggregationIncrementInterfaceNamespaceName);

                    var iServiceAggregationIncrementExtensionsStubClass = Instances.ClassGenerator.GetIServiceAggregationIncrementExtensionsClassStub(
                        iServiceAggregationIncrementInterfaceTypeName);

                    var namespaceOutput = @namespace.AddClass(iServiceAggregationIncrementExtensionsStubClass);
                    return namespaceOutput;
                });

            return output;
        }

        public static CompilationUnitSyntax GetIServiceAggregationIncrementStub(this ICompilationUnitGenerator _,
            string namespaceName)
        {
            var output = Instances.CompilationUnitGenerator.InNewNamespace(
                namespaceName,
                (@namespace, namespaceNames) =>
                {
                    namespaceNames.AddRange(
                        Instances.NamespaceName.Values().R5T_Dacia());

                    var iServiceAggregationIncrementStubInterface = Instances.InterfaceGenerator.GetIServiceAggregationIncrementStub();

                    var namespaceOutput = @namespace.AddInterface(iServiceAggregationIncrementStubInterface);
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

                    var extensionMethodBaseClass = Instances.ClassGenerator.GetExtensionMethodBase(
                        implementationTypeName,
                        interfaceTypeName);

                    var namespaceOutput = @namespace.AddClass(extensionMethodBaseClass);
                    return namespaceOutput;
                });

            return output;
        }
    }
}
