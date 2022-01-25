using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class IStatementOperatorExtensions
    {
        public static (BlockSyntax methodBody, ExpressionStatementSyntax servicesConfigurationStatement) AcquireServicesConfigurationStatement(this IStatementOperator _,
            BlockSyntax methodBody)
        {
            var hasServicesConfigurationStatement = methodBody.Statements.HasServicesConfigurationStatement();

            if (hasServicesConfigurationStatement)
            {
                return (methodBody, hasServicesConfigurationStatement);
            }
            else
            {
                // Create the statement, and add it to the method body at a chosen place.
                var servicesConfigurationStatement = Instances.StatementGenerator.CreateServicesConfigurationStatementStub()
                    .PrependBlankLine()
                    .Annotate(out var annotation);

                var outputMethodBody = methodBody.InsertStatementBefore(
                    methodBody.Statements.Last(),
                    servicesConfigurationStatement);

                // Need to find the copy of the node made when added.
                var outputServicesConfigurationStatement = outputMethodBody.GetAnnotatedNode<ExpressionStatementSyntax>(annotation);

                return (outputMethodBody, outputServicesConfigurationStatement);
            }
        }

        public static (BlockSyntax methodBody, ExpressionStatementSyntax servicesConfigurationStatement) AcquireHostBuilderStatement(this IStatementOperator _,
            BlockSyntax methodBody)
        {
            var hasHostBuilderStatement = methodBody.Statements.HasHostBuilderStatement();

            if (hasHostBuilderStatement)
            {
                return (methodBody, hasHostBuilderStatement);
            }
            // Else, TODO

            throw new Exception("No host builder statement found.");
        }
    }
}
