using Allors.Repository.Attributes;
using System;

namespace Allors.Repository
{
    [Id("cb02fff5-fa79-4186-9f83-2239d7184700")]
    public partial class Calendar : Object
    {

        #region Inherited Properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("34803f22-0f75-481f-976d-69511199256c")]
        [AssociationId("78fc5e28-0c06-47c2-9cdc-7e141a634037")]
        [RoleId("e50de87e-9b0f-4601-84d8-21d54d69380d")]
        #endregion
        [Workspace]
        public DateTime ScheduleStart { get; set; }

        #region Allors
        [Id("2d24698a-3ab6-4fe9-850f-8a0638ecca40")]
        [AssociationId("c1631250-98ca-481b-94e1-2063fa916d77")]
        [RoleId("25d96739-8980-4449-9c3f-1983edf7814a")]
        #endregion
        [Workspace] public DateTime ScheduleEnd { get; set; }

        #region Allors
        [Id("67b72f14-78ef-4ca7-9a52-f5439b9aedc4")]
        [AssociationId("ec2e5b05-a6cf-4d63-bc74-c5a783854b47")]
        [RoleId("b2f1c2df-78cb-4c69-851e-158941ce234d")]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public GymMembership GymMembership { get; set; }

        #region Allors
        [Id("a8d1ea12-0273-4e37-beff-e0c4eb0b2c07")]
        [AssociationId("d9f94281-0236-40f8-9d36-984464799e28")]
        [RoleId("17b53071-71da-4e09-9be6-c37812b45019")]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public Work Work { get; set; }

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
