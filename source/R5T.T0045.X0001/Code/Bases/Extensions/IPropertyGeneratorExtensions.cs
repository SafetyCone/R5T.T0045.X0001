using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class IPropertyGeneratorExtensions
    {
        public static PropertyDeclarationSyntax GetExtensionMethodBaseStaticInstance(this IPropertyGenerator _,
            string classTypeName)
        {
            var text = $"public static {classTypeName} {Instances.PropertyName.Instance()} {{ get; }} = new();";

            var output = _.GetPropertyFromText(text);
            return output;
        }

        public static PropertyDeclarationSyntax GetPrivateServiceProvider(this IPropertyGenerator _)
        {
            var text = $"private IServiceProvider ServiceProvider {{ get; }}";

            var output = _.GetPropertyFromText(text);
            return output;
        }
    }
}
