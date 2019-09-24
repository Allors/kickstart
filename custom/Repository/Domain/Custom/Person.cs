using Allors.Repository.Attributes;

namespace Allors.Repository
{

    public partial class Person : Deletable
    {
        #region Allors
        [Id("de2d71ff-e05e-43a0-8187-5f983d6070f8")]
        [AssociationId("a8ac537d-81e7-4774-9c5d-f7b1313fd7e2")]
        [RoleId("126579b4-380b-427e-9889-d1c6e9071b69")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public Address Address { get; set; }
        public Calendar Calendar { get; set; }

        #region inherited methods

        public void Delete()
        {
        }

        #endregion inherited methods
    }
}