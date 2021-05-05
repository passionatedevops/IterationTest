namespace Domain.Objects
{
    public class Player: GameObject, IHaveInventory
    {
        private readonly Inventory _inventory;
        private static readonly string[] DefaultIdentifiers = new[] { "me", "inventory" };

        public Player(string name, string desc) : base(DefaultIdentifiers, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            return _inventory.HasItem(id) ? _inventory.Fetch(id): null;
        }

        public override string FullDescription => string.Join("\t\n", new[] {"You are carrying:", _inventory.ItemList});
        public Inventory Inventory => _inventory;
    }
}
