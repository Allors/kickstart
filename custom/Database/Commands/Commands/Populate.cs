﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Populate.cs" company="Allors bvba">
//   Copyright 2002-2017 Allors bvba.
// 
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// 
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands
{
    using System.IO;
    using Allors;
    using Allors.Domain;
    using Allors.Services;
    using McMaster.Extensions.CommandLineUtils;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    [Command(Description = "Start with a new population")]
    public class Populate
    {
        private readonly IDatabaseService databaseService;

        private readonly ILogger<Populate> logger;

        private readonly DirectoryInfo dataPath;

        public Populate(IConfiguration configuration, IDatabaseService databaseService, ILogger<Populate> logger)
        {
            this.dataPath = new DirectoryInfo(".").GetAncestorSibling(configuration["datapath"]);
            this.databaseService = databaseService;
            this.logger = logger;
        }

        public int OnExecute(CommandLineApplication app)
        {
            this.logger.LogInformation("Begin");

            this.databaseService.Database.Init();

            using (var session = this.databaseService.Database.CreateSession())
            {
                var config = new Config { DataPath = this.dataPath, Demo = true };
                new Setup(session, config).Apply();

                session.Derive();
                session.Commit();

                var administrator = new Users(session).GetUser("administrator");
                session.SetUser(administrator);

                new Allors.Upgrade(session, this.dataPath).Execute();

                session.Derive();
                session.Commit();
            }

            this.logger.LogInformation("End");

            return ExitCode.Success;
        }
    }
}