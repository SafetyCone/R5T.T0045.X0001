using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class StatementSyntaxExtensions
    {
        public static bool IsServicesConfigurationStatement_HasMarkAsServiceCollectonConfigurationStatement(this StatementSyntax statement)
        {
            var serviceCollectionVariableName = "services";
            var serviceCollectionConfigurationStatementMarkerMethodName = "MarkAsServiceCollectonConfigurationStatement";

            var hasBaseMemberAccessExpression = statement.HasBaseMemberAccessExpression(
                out var baseMemberAccessExpression);

            if (hasBaseMemberAccessExpression)
            {
                var isMarkedAsServiceCollectonConfigurationStatement = true
                    && baseMemberAccessExpression.Expression is IdentifierNameSyntax identifierNameExpression
                    && identifierNameExpression.Identifier.Text == serviceCollectionVariableName
                    && baseMemberAccessExpression.Name.Identifier.Text == serviceCollectionConfigurationStatementMarkerMethodName
                    ;

                if (isMarkedAsServiceCollectonConfigurationStatement)
                {
                    return true;
                }
            }
            // Else return false.

            return false;
        }

        public static bool IsServicesConfigurationStatement_FirstTokenIsServices(this StatementSyntax statement)
        {
            var servicesParameterName = "services";

            var firstToken = statement.GetFirstToken();

            var output = firstToken.IsIdentifierToken() && firstToken.IsText(servicesParameterName); ;
            return output;
        }

        public static bool IsServicesConfigurationStatement(this StatementSyntax statement)
        {
            // First see if the statement is marked.
            var isMarkedStatement = statement.IsServicesConfigurationStatement_HasMarkAsServiceCollectonConfigurationStatement();
            if (isMarkedStatement)
            {
                return true;
            }

            // Then see is the statement is acts on the services variable.
            var isFirstTokenServices = statement.IsServicesConfigurationStatement_FirstTokenIsServices();
            if (isFirstTokenServices)
            {
                return isFirstTokenServices;
            }

            return false;
        }

        public static WasFound<ExpressionStatementSyntax> HasServicesConfigurationStatement(this IEnumerable<StatementSyntax> statements)
        {
            // Preferentially use the first marked statement.
            var servicesStatement = statements
                .Where(xStatement => xStatement.IsServicesConfigurationStatement_HasMarkAsServiceCollectonConfigurationStatement())
                .Cast<ExpressionStatementSyntax>()
                .FirstOrDefault();

            var servicesStatementWasFound = servicesStatement != default;
            if (servicesStatementWasFound)
            {
                var output = WasFound.From(servicesStatementWasFound, servicesStatement);
                return output;
            }

            // Then see if there is any statment acting on the services variable.
            servicesStatement = statements
                .Where(xStatement => xStatement.IsServicesConfigurationStatement_FirstTokenIsServices())
                .Cast<ExpressionStatementSyntax>()
                .FirstOrDefault();

            servicesStatementWasFound = servicesStatement != default;
            if (servicesStatementWasFound)
            {
                var output = WasFound.From(servicesStatementWasFound, servicesStatement);
                return output;
            }

            // Else, was not found.
            return WasFound.NotFound<ExpressionStatementSyntax>();
        }

        public static bool IsHostBuilderStatement(this StatementSyntax statement)
        {
            var output = statement.DescendantNodesAndSelf()
                .Where(Instances.Selector.IsHostBuilderStatementNode())
                .Any();

            return output;
        }

        public static WasFound<ExpressionStatementSyntax> HasHostBuilderStatement(this IEnumerable<StatementSyntax> statements)
        {
            var hostBuilderStatementOrDefault = statements
                .Where(xStatement => xStatement.IsHostBuilderStatement())
                .Cast<ExpressionStatementSyntax>()
                .FirstOrDefault();

            var output = WasFound.From(hostBuilderStatementOrDefault);
            return output;
        }
    }
}
