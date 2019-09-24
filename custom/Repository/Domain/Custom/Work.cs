using Allors.Repository.Attributes;
using System;

namespace Allors.Repository
{
    [Id("46fd9f5d-d618-430c-934f-e3adbdd5f33a")]
    public partial class Work : Object
    {

        #region Inherited Properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("8cf8a135-0ee3-40cc-b86b-41cfe141a9e1")]
        [AssociationId("cae5e8fe-0844-44fb-a97a-013d360f9c2e")]
        [RoleId("b1222ccb-a78a-4272-acae-9e73714a9297")]
        [Size(256)]
        #endregion
        [Workspace]
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


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
