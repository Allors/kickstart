namespace Tests.Intranet.PersonTests
{
    using Allors.Domain;
    using Allors.Meta;

    using Xunit;

    [Collection("Test collection")]
    public class PersonOverviewTest : Test
    {
        private readonly PersonListPage people;

        public PersonOverviewTest(TestFixture fixture)
            : base(fixture)
        {
            var dashboard = this.Login();
            this.people = dashboard.Sidenav.NavigateToPersonList();
        }

        [Fact]
        public void Title()
        {
            var person = new People(this.Session).FindBy(M.Person.FirstName, "John");
            this.people.Select(person);
            Assert.Equal("Person", this.Driver.Title);
        }

        [Fact]
        public void NavigateToList()
        {
            var person = new People(this.Session).FindBy(M.Person.FirstName, "John");
            var overviewPage = this.people.Select(person);
            Assert.Equal("Person", this.Driver.Title);

            overviewPage.List.Click();

            Assert.Equal("People", this.Driver.Title);
        }
    }
}
