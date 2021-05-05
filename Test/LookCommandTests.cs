using Domain.Commands;
using Domain.Objects;
using NUnit.Framework;

namespace Test
{
    public class LookCommandTests
    {
        private readonly LookCommand _lookCommand;
        private Player _player;
        private Bag _bag;

        public LookCommandTests()
        {
            _lookCommand = new LookCommand(new[] { "look" });
        }

        [SetUp]
        public void Setup()
        {
            _player = new Player("Player 1", "First Player");
        }

        [Test]
        public void TestLookAtMe() =>
            Assert.AreEqual(_player.FullDescription, _lookCommand.Execute(_player, new[] { "look", "at", "me" }));

        [Test]
        public void TestLookAtGem()
        {
            _player.Inventory.Put(new Item(new[] { "gem" }, "A Gem", "A fine gem"));
            Assert.AreEqual("A fine gem", _lookCommand.Execute(_player, new[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            _player.Inventory.Put(new Item(new[] { "gem" }, "A Gem", "A fine gem"));
            Assert.AreEqual("A fine gem", _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "Me" }));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            _bag = new Bag(new[] {"bag"}, "bag", "A fine bag");
            _bag.Inventory.Put(new Item(new[] { "gem" }, "A Gem", "A fine gem"));
            _player.Inventory.Put(_bag);
            Assert.AreEqual("A fine gem", _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "Bag" }));
        }

        [Test]
        public void TestLookAtUnk()
        {
            _player.Inventory.Take("gem");
            Assert.AreEqual("I can't find the gem", _lookCommand.Execute(_player, new[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            _bag = new Bag(new[] { "bag" }, "bag", "A fine bag");
            _player.Inventory.Put(_bag);
            Assert.AreEqual("I can't find the gem in the bag", _lookCommand.Execute(_player, new[] { "look", "at", "gem", "in", "Bag" }));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.AreEqual("I don’t know how to look like that", _lookCommand.Execute(_player, new[] { "look", "around"}));
            Assert.AreEqual("Error in look input", _lookCommand.Execute(_player, new[] { "hello", "look", "around" }));
            Assert.AreEqual("What do you want to look at?", _lookCommand.Execute(_player, new[] { "look", "in", "gem", "at", "Bag" }));
            Assert.AreEqual("What do you want to look in?", _lookCommand.Execute(_player, new[] { "look", "at", "gem", "at", "Bag" }));
        }
    }
}
