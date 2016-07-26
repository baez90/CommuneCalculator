using CommuneCalculator.DB.Models;
using NUnit.Framework;

namespace CommuneCalculator.DB.Tests.ModelTests
{
    [TestFixture]
    public class OptionalTests
    {
        [Test(Author = "Peter Kurfer", TestOf = typeof(Optional<>))]
        public void TestEmptyOptionalObjectType_ShouldReturnHasNoValue()
        {
            var emptyOptional = Optional<TestObject>.Empty<TestObject>();
            Assert.IsFalse(emptyOptional.HasValue);
        }

        [Test(Author = "Peter Kurfer", TestOf = typeof(Optional<>))]
        public void TestEmptyOptionalObjectTypeCreatedByImplicitCast_ShouldReturnHasNoValue()
        {
            //expected behavior is that default values are not recognized as actual values
            Optional<int> emptyOptional = default(int);
            Assert.IsFalse(emptyOptional.HasValue);
        }

        [Test(Author = "Peter Kurfer", TestOf = typeof(Optional<>))]
        public void TestEmptyOptionalStructType_ShouldReturnHasNoValue()
        {
            var emptyOptional = Optional<int>.Empty<int>();
            Assert.IsFalse(emptyOptional.HasValue);
        }

        [Test(Author = "Peter Kurfer", TestOf = typeof(Optional<>))]
        public void TestFilledOptionalObjectType_ShouldReturnHasValue()
        {
            var filledOptional = Optional<TestObject>.Of(new TestObject {Id = 1});
            Assert.IsTrue(filledOptional.HasValue);
        }

        [Test(Author = "Peter Kurfer", TestOf = typeof(Optional<>))]
        public void TestFilledOptionalObjectTypeCreatedByImplicitCast_ShouldReturnHasValue()
        {
            Optional<TestObject> filledOptional = new TestObject {Id = 1};
            Assert.IsTrue(filledOptional.HasValue);
        }

        [Test(Author = "Peter Kurfer", TestOf = typeof(Optional<>))]
        public void TestFilledOptionalStructType_ShouldReturnHasValue()
        {
            var filledOptional = Optional<int>.Of(1);
            Assert.IsTrue(filledOptional.HasValue);
        }

        [Test(Author = "Peter Kurfer", TestOf = typeof(Optional<>))]
        public void TestFilledOptionalStructTypeCreatedByImplicitCast_ShouldReturnHasValue()
        {
            Optional<int> filledOptional = 1;
            Assert.IsTrue(filledOptional.HasValue);
        }
    }

    internal class TestObject
    {
        public int Id { get; set; }
    }
}