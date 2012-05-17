﻿using System;
using CommandLine;
using MsBuilderific.Contracts;
using MsBuilderific.Core;
using MsBuilderific.Visitors.Build;
using MsBuilderific.Visitors.Clean;
using MsBuilderific.Core.VisualStudio;

namespace MsBuilderific.Console
{
    class Program
    {
        static void Main(string[] args)
        {            
            var options = new Options();

            if (!CommandLineParser.Default.ParseArguments(args, options, System.Console.Out))
                Environment.Exit(1);

            IProjectDependencyFinder finder = new ProjectDependencyFinder(new VisualStudio2010ProjectLoader());

            if (options.ExclusionPatterns != null)
            {
                foreach (var exclusion in options.ExclusionPatterns)
                    finder.AddExclusionPattern(exclusion);
            }

            var buildOder = finder.GetDependencyOrder(options);

            IMsBuildFileCore generator = new MsBuildFileCore();

            generator.AcceptVisitor(new CleanBuildArtefactsVisitor());
            generator.AcceptVisitor(new MsBuildProjectVisitor());
            generator.AcceptVisitor(new MsDeployProjectVisitor());
            generator.AcceptVisitor(new MsTestsProjectVisitor());
            generator.AcceptVisitor(new CopyProjectOutputVisitor());
            generator.AcceptVisitor(new CopyRessourcesVisitor(new VisualStudio2010RessourceFinder()));
            generator.AcceptVisitor(new CopyMsDeployPackagesVisitor());
            generator.AcceptVisitor(new DeleteBinAfterPackagingVisitor());

            generator.WriteBuildScript(buildOder, options);
        }
    }
}
