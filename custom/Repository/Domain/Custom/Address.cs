using Allors.Repository.Attributes;

namespace Allors.Repository
{
    [Id("b57c43ed-4e2a-4fc1-8ed7-cdc3a7067da7")]
    public partial class Address : Object
    {

        #region Inherited Properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("6165e7b6-b9b1-4ecb-a7ca-87bda8271251")]
        [AssociationId("2f81b499-0bc6-4392-960f-e1fb6363b9ab")]
        [RoleId("fa4b87ca-9789-48d0-a881-9c0e7e6d168d")]
        [Size(256)]
        #endregion
        [Workspace]
        public string Street { get; set; }

        #region Allors
        [Id("3a7354b2-c766-4b4d-9841-4f7c2d7ab541")]
        [AssociationId("7557e59c-da88-4fee-83b9-4835402b1ec5")]
        [RoleId("2f0b09ba-5e69-48ea-b90b-3b95a41c1178")]
        [Size(256)]
        #endregion
        [Workspace]
        public string City { get; set; }

        #region Allors
        [Id("5f7e677a-b88d-43df-88e7-e8548d92dd7f")]
        [AssociationId("cfe5f711-5ff4-49a1-bf1b-0db4b7949d2f")]
        [RoleId("81b6c10a-b0cf-4233-a306-3717667c9c52")]
        [Size(256)]
        #endregion
        [Workspace]
        public string Country { get; set; }

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
