using Domain;
using Domain.Objects;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class InventoryTests
    {
        private readonly Inventory _inventory;

        public InventoryTests()
        {
            _inventory = new Inventory();
        }

        [OneTimeSetUp]
        public void Setup()
        {
            _inventory.Put(new Item(new[] { "shovel", "spade" }, "a shovel", "This is a fine shovel"));
            _inventory.Put(new Item(new[] { "sword"}, "a sword", "This is a mighty sword"));
        }

        [Test]
        public void TestFindItem() =>
            Assert.True(_inventory.HasItem("shovel"));

        [Test]
        public void TestNoItemFind() =>
            Assert.False(_inventory.HasItem("gun"));

        [Test]
        public void TestFetchItem()
        {
            Assert.NotNull(_inventory.Fetch("shovel"));
            Assert.True(_inventory.HasItem("shovel"));
        }
        [Test]
        public void TestItemsList() =>
            Assert.AreEqual(_inventory.ItemList, "a shovel(shovel)\t\na sword(sword)");

        [Test]
        public void TestTakeItem()
        {
            Assert.NotNull(_inventory.Take("shovel"));
            Assert.False(_inventory.HasItem("shovel"));
        }
    }
}
