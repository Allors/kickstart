using Allors.Repository.Attributes;
using System;

namespace Allors.Repository
{
    [Id("d4275535-d610-49ba-be84-092da295e388")]
    public partial class Calendar : Object
    {

        #region Inherited Properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("82c832a5-09d4-4e00-8eee-a22a02195d8f")]
        [AssociationId("a989b43a-770d-45dc-b38a-c5266d26d0f5")]
        [RoleId("1353f15d-e756-408d-b5e5-107681843eee")]
        [Size(256)]
        #endregion
        [Workspace]
        public DateTime Schedule { get; set; }
        public string Type { get; set; }


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
