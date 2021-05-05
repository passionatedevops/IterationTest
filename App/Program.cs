using System;
using Domain.Commands;
using Domain.Objects;

namespace App
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Please enter your name");
            var name = Console.ReadLine();
            Console.WriteLine("Tell me a bit more about yourself");
            var description = Console.ReadLine();
            var player = new Player(name, description);
            var sword = new Item(new[] {"sword"}, "sword", "A fine sword");
            var gem = new Item(new[] { "gem" }, "gem", "A fine gem");
            player.Inventory.Put(sword);
            player.Inventory.Put(gem);
            var bag = new Bag(new[] {"bag"}, "bag", "A huge bag");
            player.Inventory.Put(bag);
            var bow = new Item(new[] { "bow" }, "bow", "A fine bow");
            bag.Inventory.Put(bow);
            var lookCommand = new LookCommand(new[] {"look"});
            Console.WriteLine("Please invoke the look commands");
            while (true)
            {
                var command = Console.ReadLine()?.Split(" ");
                Console.WriteLine(lookCommand.Execute(player, command));
            }
        }
    }
}
