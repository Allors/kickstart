using Allors.Repository.Attributes;
using System;

namespace Allors.Repository
{
    [Id("18642a94-8b01-4f75-b4b2-70c1311aa13b")]
    public partial class GymMembership : Object
    {

        #region Inherited Properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("23848c54-00c8-4b49-ba59-1653803ec91e")]
        [AssociationId("90b93dde-a38f-4016-9246-099f4703bc62")]
        [RoleId("b4e69a4d-5b67-446c-921f-c98b9ca52e86")]
        [Size(256)]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public string Name { get; set; }

        #region Allors
        [Id("abb2e81d-556f-4bb1-b4cf-62a1c83ddb48")]
        [AssociationId("cc82e77b-b83e-4f10-b805-cd9d0ac9e102")]
        [RoleId("3a5e88ba-16cb-4334-bc2d-736db9169504")]
        #endregion
        [Workspace] public DateTime StartTime { get; set; }

        #region Allors
        [Id("61de37f1-a07b-4550-a77e-e9ab5f57bf56")]
        [AssociationId("6f6948a7-af51-4964-bc1b-c74fadd8d3ad")]
        [RoleId("d711a998-6461-416e-bb6f-151ba37ead37")]
        #endregion
        [Workspace] public DateTime EndTime { get; set; }

        #region Allors
        [Id("b805eb82-b8bb-41ed-8768-cde2b393358f")]
        [AssociationId("00059faf-3f5c-4614-8405-8674e8b1e224")]
        [RoleId("bd9aa530-239c-4cfe-aa4d-dadfc6fa2bd1")]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace] public Address Address { get; set; }

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
