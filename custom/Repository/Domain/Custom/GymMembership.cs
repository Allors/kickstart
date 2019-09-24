using Allors.Repository.Attributes;
using System;

namespace Allors.Repository
{
    [Id("890245ec-5869-48f3-8dc8-47367315efd5")]
    public partial class GymMembership : Object
    {

        #region Inherited Properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("f401d890-60f6-43dd-8820-d131c0592535")]
        [AssociationId("36c3f829-bbf5-432c-8f5f-b2fe98448f3a")]
        [RoleId("a0125db7-6a36-4d16-920c-ac9b9abc6207")]
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
