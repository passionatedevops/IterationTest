namespace Domain.Objects
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id);
        public string Name{ get; }
    }
}
