using Domain.Objects;
using NUnit.Framework;

namespace Test
{
    public class BagTests
    {
        private readonly Bag _b1;
        private readonly Bag _b2;

        public BagTests()
        {
            _b1 = new Bag(new[] { "b1" }, "Bag 1", "First bag");
            _b2 = new Bag(new[] { "b2" }, "Bag 2", "Second bag");
        }

        [OneTimeSetUp]
        public void Setup()
        {
            _b1.Inventory.Put(new Item(new[] { "shovel", "spade" }, "a shovel", "This is a fine shovel"));
            _b2.Inventory.Put(new Item(new[] { "sword" }, "a sword", "This is a fine sword"));
            _b1.Inventory.Put(_b2);
        }

        [Test]
        public void TestBagLocatesItems() =>
            Assert.NotNull(_b1.Locate("spade"));

        [Test]
        public void TestBagLocatesItself() =>
            Assert.AreEqual(_b1, _b1.Locate("b1"));

        [Test]
        public void TestBagLocatesNothing() =>
            Assert.IsNull(_b1.Locate("sword"));

        [Test]
        public void TestBagFullDescription() =>
            Assert.True(_b1.FullDescription.Contains("In the Bag 1 you can see:"));

        [Test]
        public void TestBagInBag()
        {
            Assert.AreEqual(_b2, _b1.Locate("b2"));
            Assert.NotNull(_b1.Locate("shovel"));
            Assert.IsNull(_b1.Locate("sword"));
        }
    }
}
