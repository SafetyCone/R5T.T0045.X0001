using System;

using R5T.T0034;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class INamespacedTypeNameExtensions
    {
        public static string Startup_R5T_T0027_T009(this INamespacedTypeName _)
        {
            var output = Instances.NamespacedTypeName.GetNamespacedName(
                    Instances.NamespaceName.Values().R5T_T0027_T009(),
                    Instances.ClassName.Startup());

            return output;
        }

        public static string IServicesAggregationIncrement(this INamespacedTypeName _,
            string namespaceName)
        {
            var output = _.GetNamespacedName(
                namespaceName,
                Instances.InterfaceName.IServiceAggregationIncrement());

            return output;
        }

        public static string IServiceAggregation(this INamespacedTypeName _,
            string namespaceName)
        {
            var output = _.GetNamespacedName(
                namespaceName,
                Instances.InterfaceName.IServiceAggregation());

            return output;
        }

        public static string ServiceAggregation(this INamespacedTypeName _,
            string namespaceName)
        {
            var output = _.GetNamespacedName(
                namespaceName,
                Instances.ClassName.ServiceAggregation());

            return output;
        }
    }
}
