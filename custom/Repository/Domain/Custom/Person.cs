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

        #region Allors
        [Id("0b844a98-6ea5-49bf-95c4-64149fa5c1ca")]
        [AssociationId("86267ce3-8533-479a-a4c3-b74e3425adda")]
        [RoleId("b223e35a-49ec-433b-bdb3-99234af55a44")]
        #endregion
        [Multiplicity(Multiplicity.OneToOne)]
        [Workspace]
        public Calendar Calendar { get; set; }

        #region inherited methods

        public void Delete()
        {
        }

        #endregion inherited methods
    }
}