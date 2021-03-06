﻿using System;
using CommandLine;
using CommandLine.Text;

namespace MsBuilderific.Visitors.Build
{
    public class CopyProjectOutputVisitorOptions : CopyToOptions
    {
        /// <summary>
        /// Gets or sets a value indicating if copy pdb to the output location
        /// </summary>
        [Option(null, "copyPdbs", HelpText = "True to copy pdb to the output location, false otherwise", Required = false, DefaultValue = true)]
        public bool CopyPdbs { get; set; }

        [Option(null, "copyXml", HelpText = "True to copy xml to the output location, false otherwise", Required = false, DefaultValue = true)]       
        public bool CopyXml { get; set; }

        [Option(null, "copyExe", HelpText = "True to copy exe to the output location, false otherwise", Required = false, DefaultValue = true)]
        public bool CopyExe { get; set; }

        [Option(null, "CopyConfig", HelpText = "True to copy config files to the output location, false otherwise", Required = false, DefaultValue = true)]
        public bool CopyConfig { get; set; }

        [Option(null, "CopyDll", HelpText = "True to copy dll to the output location, false otherwise", Required = false, DefaultValue = true)]
        public bool CopyDll { get; set; }

        [Option(null, "CopyCodeContracts", HelpText = "True to copy code contracts (Microsoft) to the output location, false otherwise", Required = false, DefaultValue = true)]
        public bool CopyCodeContracts { get; set; }

        [Option(null, "CopyRessources", HelpText = "True to copy project ressources to the output location, false otherwise", Required = false, DefaultValue = true)]
        public bool CopyRessources { get; set; }

        [Option(null, "CopyEnabled", HelpText = "True to copy to the output location, false otherwise", Required = false, DefaultValue = true)]
        public bool CopyEnabled { get; set; }

        #region Public Methods

        [HelpOption("?", "help", HelpText = "Display MsBuilderific help")]
        public String GetUsage()
        {
            var help = new HelpText(new HeadingInfo("Copy project output Visitor", null).ToString())
            {
                MaximumDisplayWidth = Console.WindowWidth,
                Copyright = new CopyrightInfo("Vooban Inc.", 2011)
            };

            help.AddPreOptionsLine("");
            help.AddOptions(this);
            help.AddPostOptionsLine("\r\n"); 

            return help;
        }

        #endregion
    }

}
