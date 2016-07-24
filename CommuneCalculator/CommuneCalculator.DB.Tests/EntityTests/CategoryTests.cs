using CommuneCalculator.DB.Entities;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace CommuneCalculator.DB.Tests.EntityTests
{
    [TestFixture]
    public class CategoryTests
    {

        private Category _testCategory;

        [SetUp]
        public void SetupTests()
        {
            _testCategory = new Category();
        }

        [Test(Author = "Peter Kurfer", TestOf = typeof(Category), Description = "Test if Shops collection is initialized correctly")]
        public void TestGetShops_ShouldNotReturnNull()
        {
            NotNull(_testCategory.Shops);
        }
    }
}