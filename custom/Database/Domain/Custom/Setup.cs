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
using System;

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
                    .WithUserEmail("jane@example.com")
                    .WithUserName("jane@example.com")
                    .WithFirstName("Jane")
                    .WithMiddleName("Joanne")
                    .WithLastName("Doe")
                    .WithAddress(new AddressBuilder(this.session).WithCity("Mechelen").Build())
                    .Build();

                var jenny = new PersonBuilder(this.session)
                    .WithUserEmail("jenny@example.com")
                    .WithUserName("jenny@example.com")
                    .WithFirstName("Jenny")
                    .WithLastName("Doe")
                    .WithAddress(new AddressBuilder(this.session).WithCity("Antwerp").Build())
                    .Build();

                var john = new PersonBuilder(this.session)
                    .WithUserEmail("john@example.com")
                    .WithUserName("john@example.com")
                    .WithFirstName("John")
                    .WithLastName("Doe")
                    .WithAddress(new AddressBuilder(this.session).WithCity("Brussels").Build())
                    .Build();

                var jubayer = new PersonBuilder(this.session)
                    .WithUserEmail("jubayer@example.com")
                    .WithUserName("jubayer@example.com")
                    .WithFirstName("Sharif")
                    .WithMiddleName("Jubayer")
                    .WithLastName("Arefin")
                    .WithAddress(new AddressBuilder(this.session).WithCity("Dhaka").Build())
                    .WithCalendar(
                    //Setup Calendar
                        new CalendarBuilder(this.session)
                            .WithScheduleStart(
                                new DateTime(2019, 9, 25, 9, 0, 0).ToUniversalTime()
                            )
                            .WithScheduleEnd(
                                new DateTime(2019, 9, 25, 20, 0, 0).ToUniversalTime()
                            )
                            //Setup GymMembership
                            .WithGymMembership(
                                new GymMembershipBuilder(this.session)
                                .WithName("Gold's GYM")
                                .WithStartTime(
                                    new DateTime(2019, 9, 25, 18, 30, 0).ToUniversalTime()
                                )
                                .WithEndTime(
                                    new DateTime(2019, 9, 25, 20, 0, 0).ToUniversalTime()
                                )
                                .WithAddress(new AddressBuilder(this.session).WithCity("Cox's Bazaar").Build())
                                .Build()
                            )
                            //Setup Work
                            .WithWork(
                                new WorkBuilder(this.session)
                                .WithName("Allors")
                                .WithStartTime(
                                    new DateTime(2019, 9, 25, 9, 0, 0).ToUniversalTime()
                                )
                                .WithEndTime(
                                    new DateTime(2019, 9, 25, 18, 0, 0).ToUniversalTime()
                                )
                                .WithAddress(new AddressBuilder(this.session).WithCity("Cox's Bazaar").Build())
                                .Build()
                            )
                        .Build()
                    )
                    .Build();

                jane.UserPasswordHash = passwordService.HashPassword(jane.UserName, "jane");
                jenny.UserPasswordHash = passwordService.HashPassword(jenny.UserName, "jenny");
                john.UserPasswordHash = passwordService.HashPassword(john.UserName, "john");
                jubayer.UserPasswordHash = passwordService.HashPassword(jubayer.UserName, "jubayer");

                var administrators = new UserGroups(this.session).Administrators;
                var creators = new UserGroups(this.session).Creators;
                var employees = new UserGroups(this.session).Employees;

                administrators.AddMember(jane);
                administrators.AddMember(jubayer);
                creators.AddMember(jane);
                creators.AddMember(jenny);
                creators.AddMember(john);
                creators.AddMember(jubayer);
                employees.AddMember(jane);
                employees.AddMember(jenny);
            }
        }
    }
}