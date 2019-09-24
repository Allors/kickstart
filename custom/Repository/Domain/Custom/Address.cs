using Allors.Repository.Attributes;

namespace Allors.Repository
{
    [Id("190b3de0-c946-4e1d-8ee9-edcb6597133a")]
    public partial class Address : Object
    {

        #region Inherited Properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("5be5fdf3-5de2-4b3b-b2e0-9cae738413a3")]
        [AssociationId("43d563ea-53a2-437f-be9d-26ae14f3301f")]
        [RoleId("c7ffc8dc-bda6-4255-8c85-4a59a58210f6")]
        [Size(256)]
        #endregion
        [Workspace]
        public string City { get; set; }


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
