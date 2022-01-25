using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0060;


namespace System
{
    public static class ISelectorExtensions
    {
        public static Func<SyntaxNode, bool> IsHostBuilderStatementNode(this ISelector _)
        {
            // Inputs.
            var hostPropertyName = "Host";
            var instancesTypeName = "Instances";
            var newBuilderMethodName = "NewBuilder";

            return xNode =>
            {
                if (xNode is MemberAccessExpressionSyntax memberAccessExpression
                    && memberAccessExpression.IsKind(SyntaxKind.SimpleMemberAccessExpression)
                    && memberAccessExpression.Name.Identifier.Text == newBuilderMethodName)
                {
                    if (memberAccessExpression.Expression is MemberAccessExpressionSyntax childMemberAccessExpression
                        && childMemberAccessExpression.IsKind(SyntaxKind.SimpleMemberAccessExpression)
                        && childMemberAccessExpression.Name.Identifier.Text == hostPropertyName)
                    {
                        if (childMemberAccessExpression.Expression is IdentifierNameSyntax identifierName
                            && identifierName.Identifier.Text == instancesTypeName)
                        {
                            return true;
                        }
                    }
                }

                return false;
            };
        }
    }
}
