// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Setup.cs" company="Allors bvba">
//   Copyright 2002-2016 Allors bvba.
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

using Allors.Domain;
using Allors.Meta;
using Allors.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Allors
{
    public partial class Setup
    {
        private void CustomOnPrePrepare()
        {
        }

        private void CustomOnPostPrepare()
        {
        }

        private void CustomOnPreSetup()
        {
        }

        private void CustomOnPostSetup()
        {
            if (this.Config.Demo)
            {
                var passwordService = this.session.ServiceProvider.GetRequiredService<IPasswordService>();

                var jane = new PersonBuilder(this.session)
                    .WithUserName("jane@example.com")
                    .WithFirstName("Jane")
                    .WithLastName("Doe")
                    .Build();

                var jenny = new PersonBuilder(this.session)
                    .WithUserName("jenny@example.com")
                    .WithFirstName("Jenny")
                    .WithLastName("Doe")
                    .Build();

                var john = new PersonBuilder(this.session)
                    .WithUserName("john@example.com")
                    .WithFirstName("John")
                    .WithLastName("Doe")
                    .Build();

                jane.UserPasswordHash = passwordService.HashPassword(jane.UserName, "jane");
                jenny.UserPasswordHash = passwordService.HashPassword(jenny.UserName, "jenny");
                john.UserPasswordHash = passwordService.HashPassword(john.UserName, "john");

                var administrators = new UserGroups(this.session).Administrators;
                var creators = new UserGroups(this.session).Creators;
                var employees = new UserGroups(this.session).Employees;

                administrators.AddMember(jane);
                creators.AddMember(jane);
                creators.AddMember(jenny);
                creators.AddMember(john);
                employees.AddMember(jane);
                employees.AddMember(jenny);
            }
        }
    }
}