using Allors.Repository.Attributes;
using System;

namespace Allors.Repository
{
    [Id("d9d5b399-6690-4748-b85c-9af311228906")]
    public partial class Work : Object
    {

        #region Inherited Properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("096bc82f-50dc-41c2-a8e8-8fe36c8c5f21")]
        [AssociationId("9b89a99b-e6d9-4786-9206-e8f2520ecfee")]
        [RoleId("702b8883-4e19-4839-b4ac-164187a47cc2")]
        [Size(256)]
        #endregion
        [Workspace]
        public string Name { get; set; }

        #region Allors
        [Id("e47f31b0-7272-425a-b4ef-26691cb01c8c")]
        [AssociationId("38d0dcf0-31ef-4c58-91fa-4d1beb4f974b")]
        [RoleId("ce549c57-ff41-4777-aa5b-47707b0df644")]
        #endregion
        [Workspace]
        public DateTime StartTime { get; set; }

        #region Allors
        [Id("d2907b02-ea3f-4101-b5cf-fba1ef39e98a")]
        [AssociationId("c753e79e-ec08-4e2e-b68f-a6e82034872c")]
        [RoleId("db187c98-ec33-42cd-b76b-392840e81393")]
        #endregion
        [Workspace]
        public DateTime EndTime { get; set; }

        #region Allors
        [Id("3913cc19-319a-467b-99f3-2d0d0ef1ef8f")]
        [AssociationId("bd24f718-e24b-4b69-931b-68cae14cc339")]
        [RoleId("acc5690f-d58b-4c44-a33c-d7e467b76538")]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public Address Address { get; set; }

        #region inherited methods

        public void OnBuild() { }

        public void OnPostBuild() { }

        public void OnInit()
        {
        }

        public void OnPreDerive() { }

        public void OnDerive() { }

        public void OnPostDerive() { }

        #endregion
    }
}
