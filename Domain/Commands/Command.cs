using Domain.Objects;

namespace Domain.Commands
{
    public abstract class Command : IdentifiableObject
    {
        protected Command(string[] idents) : base(idents)
        {
        }
        public abstract string Execute(Player p, string[] text);
    }
}
