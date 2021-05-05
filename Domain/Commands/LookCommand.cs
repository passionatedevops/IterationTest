using System;
using System.Linq;
using Domain.Objects;

namespace Domain.Commands
{
    public class LookCommand: Command
    {
        public LookCommand(string[] idents) : base(idents)
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5)
            {
                return "I don’t know how to look like that";
            }
            else
            {
                if (!text.First().Equals("look", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "Error in look input";
                }

                if (!text[1].Equals("at", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "What do you want to look at?";
                }

                if (text.Length == 5 && !(text[3].Equals("in", StringComparison.InvariantCultureIgnoreCase)))
                {
                    return "What do you want to look in?";
                }
            }

            return LookAtIn(text[2], text.Length == 3 ? p : FetchContainer(p, text[4]));
        }

        private IHaveInventory FetchContainer(Player p, string containerId) =>
            p.Locate(containerId) as IHaveInventory;

        private string LookAtIn(string thingId, IHaveInventory container) =>
            container.Locate(thingId)?.FullDescription ?? $"I can't find the {thingId}{(container is Player ? "" : $" in the {container.Name}")}";
    }
}
