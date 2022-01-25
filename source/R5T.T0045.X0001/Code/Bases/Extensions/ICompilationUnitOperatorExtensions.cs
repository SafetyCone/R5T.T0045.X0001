using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class ICompilationUnitOperatorExtensions
    {
        public static async Task<CompilationUnitSyntax> ModifyProgramAsAService_AddSerializeServiceCollectionAudit(this ICompilationUnitOperator _,
            CompilationUnitSyntax compilationUnit)
        {
            // Inputs.
            var buildMethodName = "SerializeConfigurationAudit";
            var serializeConfigurationAuditMethodName = "SerializeServiceCollectionAudit";

            var outputCompilationUnit = await compilationUnit.ModifyClassMethod(
                Instances.Selector.ClassNamed(Instances.ClassName.Program()),
                Instances.Selector.MethodNamed(Instances.MethodName.Main()),
                async method =>
                {
                    var outputMethod = await method.ModifyMethodBody(
                        methodBody =>
                        {
                            // Acquire the host builder statement (find or create new if none found).
                            //  // Identify the host builder statement. A MemberAccessExpression with Name=NewBuilder, and a child expression that is a member access expression with an IdentifierName expresion=Instances, and a Name=Host.
                            var (outputMethodBody, unmodifiedHostBuilderStatement) = Instances.StatementOperator.AcquireHostBuilderStatement(methodBody);

                            var hostBuilderStatement = unmodifiedHostBuilderStatement.MoveAllNewLinesToLeadingTrivia();

                            var newHostBuilderStatement = Instances.StatementOperator.InsertFluentMethodCallAfter(
                                hostBuilderStatement,
                                serializeConfigurationAuditMethodName,
                                buildMethodName);

                            outputMethodBody = outputMethodBody.ReplaceNode(unmodifiedHostBuilderStatement, newHostBuilderStatement);

                            return Task.FromResult(outputMethodBody);
                        });

                    return outputMethod;
                });

            return outputCompilationUnit;
        }

        public static async Task<CompilationUnitSyntax> ModifyProgramAsAService_AddSerializeConfigurationAudit(this ICompilationUnitOperator _,
            CompilationUnitSyntax compilationUnit)
        {
            // Inputs.
            var buildMethodName = "Build";
            var serializeConfigurationAuditMethodName = "SerializeConfigurationAudit";

            var outputCompilationUnit = await compilationUnit.ModifyClassMethod(
                Instances.Selector.ClassNamed(Instances.ClassName.Program()),
                Instances.Selector.MethodNamed(Instances.MethodName.Main()),
                async method =>
                {
                    var outputMethod = await method.ModifyMethodBody(
                        methodBody =>
                        {
                            // Acquire the host builder statement (find or create new if none found).
                            //  // Identify the host builder statement. A MemberAccessExpression with Name=NewBuilder, and a child expression that is a member access expression with an IdentifierName expresion=Instances, and a Name=Host.
                            var (outputMethodBody, unmodifiedHostBuilderStatement) = Instances.StatementOperator.AcquireHostBuilderStatement(methodBody);

                            var hostBuilderStatement = unmodifiedHostBuilderStatement.MoveAllNewLinesToLeadingTrivia();

                            var newHostBuilderStatement = Instances.StatementOperator.InsertFluentMethodCallAfter(
                                hostBuilderStatement,
                                serializeConfigurationAuditMethodName,
                                buildMethodName);

                            outputMethodBody = outputMethodBody.ReplaceNode(unmodifiedHostBuilderStatement, newHostBuilderStatement);

                            return Task.FromResult(outputMethodBody);
                        });

                    return outputMethod;
                });

            return outputCompilationUnit;
        }

        public static async Task<CompilationUnitSyntax> ModifyProgramAsAService_Initial(this ICompilationUnitOperator _,
            CompilationUnitSyntax compilationUnit,
            string namespaceName)
        {
            // Get using directives.
            var usingDirectives = compilationUnit.GetUsingDirectivesSpecification();

            usingDirectives.AddUsingNamespaceNames(
                Instances.NamespaceName.Values().System(),
                Instances.NamespaceName.Values().System_Threading(),
                Instances.NamespaceName.Values().System_Threading_Tasks(),
                Instances.NamespaceName.Values().Microsoft_Extensions_Hosting(),
                Instances.NamespaceName.Values().R5T_D0088(),
                Instances.NamespaceName.Values().R5T_D0090());

            var outputCompilationUnit = await compilationUnit
                .SetUsings(usingDirectives)
                .InNamespace(namespaceName,
                @namespace =>
                {
                    var programAsAServiceClass = Instances.ClassGenerator.GetProgramAsAServiceProgram(
                       namespaceName);

                    var outputNamespace = @namespace.AddClass(programAsAServiceClass);

                    return Task.FromResult(outputNamespace);
                })
                ;

            return outputCompilationUnit;
        }
    }
}
