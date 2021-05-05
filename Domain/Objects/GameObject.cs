namespace Domain.Objects
{
    public abstract class GameObject: IdentifiableObject
    {
        private readonly string _description;
        private readonly string _name;

        protected GameObject(string[] idents, string name, string description) : base(idents)
        {
            _description = description;
            _name = name;
        }

        public string Name => _name;
        public string ShortDescription => $"{_name}({FirstId})";
        public virtual string FullDescription => _description;
    }
}
