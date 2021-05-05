using Domain;
using Domain.Objects;
using NUnit.Framework;

namespace Test
{
    public class PlayerTests
    {
        private readonly Player _player;

        public PlayerTests()
        {
            _player = new Player("Player 1", "First Player");
        }

        [OneTimeSetUp]
        public void Setup()
        {
            _player.Inventory.Put(new Item(new[] { "shovel", "spade" }, "a shovel", "This is a fine shovel"));
        }


        [Test]
        public void TestPlayerIdentifiableWithMe() =>
            Assert.True(_player.AreYou("me"));

        [Test]
        public void TestPlayerIdentifiableWithInventory() =>
            Assert.True(_player.AreYou("inventory"));

        [Test]
        public void TestPlayerLocateWithMe() =>
            Assert.AreEqual(_player.Locate("me"), _player);

        [Test]
        public void TestPlayerLocateWithInventory() =>
            Assert.AreEqual(_player.Locate("inventory"), _player);

        [Test]
        public void TestPlayerLocateNothing() =>
            Assert.Null(_player.Locate("sword"));

        [Test]
        public void TestPlayerDescription()
        {
            Assert.True(_player.FullDescription.Contains("You are carrying:"));
            Assert.True(_player.FullDescription.Contains("shovel"));
        }
    }
}
