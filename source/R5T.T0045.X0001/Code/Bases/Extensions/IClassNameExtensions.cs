using System;

using R5T.T0036;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class IClassNameExtensions
    {
        public static string IServiceAggregationExtensions(this IClassName _)
        {
            var output = Instances.TypeName.GetExtensionsOfTypeNameTypeName(
                Instances.InterfaceName.IServiceAggregation());

            return output;
        }

        public static string IServiceAggregationIncrementExtensions(this IClassName _)
        {
            var output = Instances.TypeName.GetExtensionsOfTypeNameTypeName(
                Instances.InterfaceName.IServiceAggregationIncrement());

            return output;
        }
    }
}
