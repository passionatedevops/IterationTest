using Domain;
using Domain.Objects;
using NUnit.Framework;

namespace Test
{
    public class ItemObjectTests
    {
        private readonly Item _item;

        public ItemObjectTests()
        {
            _item = new Item(new[] { "shovel", "spade" }, "a shovel","This is a fine shovel");
        }

        [Test]
        public void TestItemIsIdentifiable() =>
            Assert.True(_item.AreYou("shovel"));

        [Test]
        public void TestShortDescription() =>
            Assert.AreEqual(_item.ShortDescription, "a shovel(shovel)");

        [Test]
        public void TestFullDescription() =>
            Assert.AreEqual(_item.FullDescription, "This is a fine shovel");
    }
}
