using System.Linq;
using System.Collections.Generic;

namespace Domain.Objects
{
    public class Inventory
    {
        private readonly List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id) => _items.Any(item => item.AreYou(id));

        public void Put(Item item) => _items.Add(item);

        public Item Take(string id)
        {
            var targetItem = _items.FirstOrDefault(item => item.AreYou(id));
            _items.Remove(targetItem);
            return targetItem;
        }

        public Item Fetch(string id) => _items.FirstOrDefault(item => item.AreYou(id));
        public string ItemList => string.Join("\t\n", _items.Select(item => item.ShortDescription));
    }
}
