using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

partial class Build
{
    Target CustomGenerate => _ => _
        .After(Clean)
        .Executes(() =>
        {
            DotNetRun(s => s
                .SetProjectFile(Paths.PlatformRepositoryGenerate)
                .SetApplicationArguments($"{Paths.CustomRepositoryDomainRepository} {Paths.PlatformRepositoryTemplatesMetaCs} {Paths.CustomDatabaseMetaGenerated}"));
            DotNetRun(s => s
                .SetWorkingDirectory(Paths.Custom)
                .SetProjectFile(Paths.CustomDatabaseGenerate));
        });

    Target CustomDatabaseTestDomain => _ => _
        .DependsOn(CustomGenerate)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(Paths.CustomDatabaseDomainTests)
                .SetLogger("trx;LogFileName=CustomDatabaseDomain.trx")
                .SetResultsDirectory(Paths.ArtifactsTests));
        });

    Target CustomPublishCommands => _ => _
        .DependsOn(CustomGenerate)
        .Executes(() =>
        {
            var dotNetPublishSettings = new DotNetPublishSettings()
                .SetWorkingDirectory(Paths.CustomDatabaseCommands)
                .SetOutput(Paths.ArtifactsCustomCommands);
            DotNetPublish(dotNetPublishSettings);
        });

    Target CustomPublishServer => _ => _
        .DependsOn(CustomGenerate)
        .Executes(() =>
        {
            var dotNetPublishSettings = new DotNetPublishSettings()
                .SetWorkingDirectory(Paths.CustomDatabaseServer)
                .SetOutput(Paths.ArtifactsCustomServer);
            DotNetPublish(dotNetPublishSettings);
        });

    Target CustomWorkspaceSetup => _ => _
        .DependsOn(CustomGenerate);
    
    Target CustomDatabaseTest => _ => _
        .DependsOn(CustomDatabaseTestDomain);

    Target CustomTest => _ => _
        .After(Clean)
        .DependsOn(CustomDatabaseTest);

    Target Custom => _ => _
        .DependsOn(Clean)
        .DependsOn(CustomTest);
}
