using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;


namespace System
{
    public static class IStatementGeneratorExtensions
    {
        public static ExpressionStatementSyntax CreateServicesConfigurationStatementStub(this IStatementGenerator _)
        {
            var text = @"
// Run.
services.MarkAsServiceCollectonConfigurationStatement()
    ;
";

            var statement = _.GetStatementFromText(text) as ExpressionStatementSyntax;
            return statement;
        }
    }
}
