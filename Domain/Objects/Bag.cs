namespace Domain.Objects
{
    public class Bag: Item, IHaveInventory
    {
        private readonly Inventory _inventory;
        public Bag(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            return _inventory.HasItem(id) ? _inventory.Fetch(id) : null;
        }

        public override string FullDescription => string.Join("\t\n", new[] { $"In the {Name} you can see:", _inventory.ItemList });

        public Inventory Inventory => _inventory;
    }
}
