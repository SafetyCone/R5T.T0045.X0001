using System;
using System.Linq;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class ICodeDirectoryOperatorExtensions
    {
        public static string[] GetServiceClassesDirectoryFilePaths(this ICodeDirectoryOperator _,
            string projectDirectoryPath)
        {
            var projectServiceClassesDirectoryPath = Instances.ProjectPathsOperator.GetServiceClassesDirectoryPath(projectDirectoryPath);

            var serviceClassesDirectoryFilePaths = Instances.FileSystemOperator.EnumerateAllDescendentFilePathsOrEmptyIfNotExists(projectServiceClassesDirectoryPath);

            var output = serviceClassesDirectoryFilePaths.ToArray();
            return output;
        }

        public static Func<string, string[]> GetServiceClassesDirectoryFilePathsGenerator(this ICodeDirectoryOperator _)
        {
            string[] Output(string projectDirectoryPath) => _.GetServiceDefinitionDirectoryFilePaths(projectDirectoryPath);
            return Output;
        }

        public static string[] GetServiceDefinitionDirectoryFilePaths(this ICodeDirectoryOperator _,
            string projectDirectoryPath)
        {
            var projectServiceDefinitionsDirectoryPath = Instances.ProjectPathsOperator.GetServicesDefinitionsDirectoryPath(projectDirectoryPath);

            var serviceDefinitionDirectoryFilePaths = Instances.FileSystemOperator.EnumerateAllDescendentFilePathsOrEmptyIfNotExists(projectServiceDefinitionsDirectoryPath);

            var output = serviceDefinitionDirectoryFilePaths.ToArray();
            return output;
        }

        public static Func<string, string[]> GetServiceDefinitionDirectoryFilePathsGenerator(this ICodeDirectoryOperator _)
        {
            string[] Output(string projectDirectoryPath) => _.GetServiceDefinitionDirectoryFilePaths(projectDirectoryPath);
            return Output;
        }

        public static string[] GetServiceImplementationDirectoryFilePaths(this ICodeDirectoryOperator _,
            string projectDirectoryPath)
        {
            var projectSerivceImplementationDirectoryPath = Instances.ProjectPathsOperator.GetServiceImplementationsDirectoryPath(projectDirectoryPath);

            var serviceImplementationDirectoryFilePaths = Instances.FileSystemOperator.EnumerateAllDescendentFilePathsOrEmptyIfNotExists(projectSerivceImplementationDirectoryPath);

            var output = serviceImplementationDirectoryFilePaths.ToArray();
            return output;
        }

        public static Func<string, string[]> GetServiceImplementationDirectoryFilePathsGenerator(this ICodeDirectoryOperator _)
        {
            string[] Output(string projectDirectoryPath) => _.GetServiceImplementationDirectoryFilePaths(projectDirectoryPath);
            return Output;
        }

        public static string[] GetServiceInterfaceDirectoryFilePaths(this ICodeDirectoryOperator _,
            string projectDirectoryPath)
        {
            var projectServiceInterfacesDirectoryPath = Instances.ProjectPathsOperator.GetServicesInterfacesDirectoryPath(projectDirectoryPath);

            var serviceInterfacesDirectoryFilePaths = Instances.FileSystemOperator.EnumerateAllDescendentFilePathsOrEmptyIfNotExists(projectServiceInterfacesDirectoryPath);

            var output = serviceInterfacesDirectoryFilePaths.ToArray();
            return output;
        }

        public static Func<string, string[]> GetServiceInterfaceDirectoryFilePathsGenerator(this ICodeDirectoryOperator _)
        {
            string[] Output(string projectDirectoryPath) => _.GetServiceInterfaceDirectoryFilePaths(projectDirectoryPath);
            return Output;
        }

        public static string[] GetBasesIntefacesDirectoryFilePaths(this ICodeDirectoryOperator _,
            string projectDirectoryPath)
        {
            var projectBasesIntefacesDirectoryPath = Instances.ProjectPathsOperator.GetBasesInterfacesDirectoryPathFromProjectDirectoryPath(projectDirectoryPath);

            var basesInterfacesDirectoryFilePaths = Instances.FileSystemOperator.EnumerateAllDescendentFilePathsOrEmptyIfNotExists(projectBasesIntefacesDirectoryPath);

            var output = basesInterfacesDirectoryFilePaths.ToArray();
            return output;
        }

        public static Func<string, string[]> GetBasesIntefacesDirectoryFilePathsGenerator(this ICodeDirectoryOperator _)
        {
            string[] Output(string projectDirectoryPath) => _.GetBasesIntefacesDirectoryFilePaths(projectDirectoryPath);
            return Output;
        }

        public static string[] GetBasesExtensionsDirectoryFilePaths(this ICodeDirectoryOperator _,
            string projectDirectoryPath)
        {
            var projectBasesExtensionsDirectoryPath = Instances.ProjectPathsOperator.GetBasesExtensionsDirectoryPath(projectDirectoryPath);

            var basesExtensionsDirectoryFilePaths = Instances.FileSystemOperator.EnumerateAllDescendentFilePathsOrEmptyIfNotExists(projectBasesExtensionsDirectoryPath);

            var output = basesExtensionsDirectoryFilePaths.ToArray();
            return output;
        }

        public static Func<string, string[]> GetBasesExtensionsDirectoryFilePathsGenerator(this ICodeDirectoryOperator _)
        {
            string[] Output(string projectDirectoryPath) => _.GetBasesExtensionsDirectoryFilePaths(projectDirectoryPath);
            return Output;
        }
    }
}
