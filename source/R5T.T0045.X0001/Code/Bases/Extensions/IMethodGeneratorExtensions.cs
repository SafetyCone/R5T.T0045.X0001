﻿using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.T0045;

using Instances = R5T.T0045.X0001.Instances;


namespace System
{
    public static class IMethodGeneratorExtensions
    {
        public static MethodDeclarationSyntax GetFillFromMethod(this IMethodGenerator _,
            string serviceAggregationInterfaceTypeName)
        {
            var text = $@"
public static T FillFrom<T>(this T aggregation,
    {serviceAggregationInterfaceTypeName} other)
    where T : {serviceAggregationInterfaceTypeName}
{{

}}
";
            var output = _.GetMethodDeclarationFromText(text)
                .IndentBlock(Instances.Indentation.Method())
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetT0027_T009ConfigureServicesWithProvidedServices(this IMethodGenerator _)
        {
            var text = @"
protected override async Task ConfigureServicesWithProvidedServices(
    IServiceCollection services,
    IServiceAction<IConfiguration> configurationAction,
    IServiceProvider startupServicesProvider,
    IProvidedServices providedServices)
{
    await base.ConfigureServicesWithProvidedServices(
        services,
        configurationAction,
        startupServicesProvider,
        providedServices);

    // Services.

    // Operations.

    // Run.
    // services
    //     .Run()
    //     ;
}
";

            var output = _.GetMethodDeclarationFromText(text)
                .IndentBlock(Instances.Indentation.Method())
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetT0027_T009ConfigureConfiguration(this IMethodGenerator _)
        {
            var text = @"
public override async Task ConfigureConfiguration(
    IConfigurationBuilder configurationBuilder,
    IServiceProvider startupServicesProvider)
{
    
}
";
            var output = _.GetMethodDeclarationFromText(text)
                .IndentBlock(Instances.Indentation.Method())
                ;

            return output;
        }

        public static ConstructorDeclarationSyntax GetT0027_T009StartupConstructor(this IMethodGenerator _)
        {
            var text = @"
public Startup(ILogger<Startup> logger)
    : base(logger)
{

}
";
            var output = _.GetConstructorDeclarationFromText(text)
                .IndentBlock(Instances.Indentation.Method())
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetProgramAsAServiceRunMethod(this IMethodGenerator _)
        {
            var text = @"
private async Task RunMethod()
{

}
";
            var output = _.GetMethodDeclarationFromText(text)
                .IndentBlock(Instances.Indentation.Method())
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetProgramAsAServiceRunOperation(this IMethodGenerator _)
        {
            var text = @"
private async Task RunOperation()
{

}
";
            var output = _.GetMethodDeclarationFromText(text)
                .IndentBlock(Instances.Indentation.Method())
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetProgramAsAServiceServiceMain(this IMethodGenerator _)
        {
            var text = @"
protected override Task ServiceMain(CancellationToken stoppingToken)
{
    return this.RunOperation();
}
";
            var output = _.GetMethodDeclarationFromText(text)
                .IndentBlock(Instances.Indentation.Method())
                ;

            return output;
        }

        public static ConstructorDeclarationSyntax GetProgramAsAServiceProgramConstructor(this IMethodGenerator _)
        {
            var text = @"
public Program(IApplicationLifetime applicationLifetime,
    IServiceProvider serviceProvider)
    : base(applicationLifetime)
{
    this.ServiceProvider = serviceProvider;
}
";
            var output = _.GetConstructorDeclarationFromText(text)
                .IndentBlock(Instances.Indentation.Method())
                ;

            return output;
        }

        public static MethodDeclarationSyntax GetProgramAsAServiceMain(this IMethodGenerator _)
        {
            var text = @"
static Task Main()
{
    return ApplicationBuilder.Instance
        .NewApplication()
        .UseProgramAsAService<Program>()
        .UseT0027_T009_TwoStageStartup<Startup>()
        .BuildProgramAsAServiceHost()
        .Run();
}
";
            var output = _.GetMethodDeclarationFromText(text)
                .IndentBlock(Instances.Indentation.Method())
                ;

            return output;
        }
    }
}
