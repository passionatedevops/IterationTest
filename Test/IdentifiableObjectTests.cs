using Domain;
using Domain.Objects;
using NUnit.Framework;

namespace Test
{
    public class IdentifiableObjectTests
    {
        private IdentifiableObject _identifiableObject;
        [SetUp]
        public void Setup()
        {
            _identifiableObject = new IdentifiableObject(new[] {"fred", "bob"});
        }

        [Test]
        public void TestAreYou() =>
            Assert.True(_identifiableObject.AreYou("fred"));

        [Theory]
        public void TestNotAreYou() =>
            Assert.False(_identifiableObject.AreYou("mario"));

        [Theory]
        public void TestCaseSensitiveAreYou() =>
            Assert.True(_identifiableObject.AreYou("fRed"));

        [Theory]
        public void TestFirstId() =>
            Assert.AreEqual(_identifiableObject.FirstId, "fred");

        [Theory]
        public void TestAddId()
        {
            _identifiableObject.AddIdentifier("wilma");
            Assert.True(_identifiableObject.AreYou("wilma"));

        }
    }
}