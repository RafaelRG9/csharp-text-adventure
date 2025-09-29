// --- World Creation ---
World gameWorld = new World();

// --- Player Creation ---
// Create a new player and place them in the starting room
Player player = new Player(gameWorld.Rooms[0]);

// --- Game Loop ---
while (true)
{
    // Describe the current room at the start of every turn.
    Console.WriteLine($"\nYou are in: {player.CurrentRoom.Name}");
    Console.WriteLine(player.CurrentRoom.Description);

    //Check for items in the room
    if (player.CurrentRoom.ItemsInRoom.Count > 0)
    {
        Console.WriteLine($"After carefully inspecting the room you find:");
        Console.WriteLine("");
        foreach (Item item in player.CurrentRoom.ItemsInRoom)
        {
            Console.WriteLine(item.Name);
            Console.WriteLine(item.Description);
            Console.WriteLine("");

        }
    }

    // Ask for a command
    Console.WriteLine("Where do you go or what do you do?");
    Console.Write("> ");

    // Read and split input to extract commands
    var playerAction = Console.ReadLine();

    if (string.IsNullOrEmpty(playerAction))
    {
        Console.WriteLine("Please enter a command.");
        continue;
    }
    string[] words = playerAction.ToLower().Split(' ');
    string verb = words[0];

    switch (verb)
    {
        // Where to go to
        case "north":
        case "south":
        case "east":
        case "west":
            switch (verb)
            {
                case "north":
                    if (player.CurrentRoom.North != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.North;
                    }
                    else
                    {
                        Console.WriteLine("There is no exit to the north.");
                    }
                    break;
                case "south":
                    if (player.CurrentRoom.South != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.South;
                    }
                    else
                    {
                        Console.WriteLine("There is no exit to the south.");
                    }
                    break;
                case "east":
                    if (player.CurrentRoom.East != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.East;
                    }
                    else
                    {
                        Console.WriteLine("There is no exit to the east.");
                    }
                    break;
                case "west":
                    if (player.CurrentRoom.West != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.West;
                    }
                    else
                    {
                        Console.WriteLine("There is no exit to the west.");
                    }
                    break;
            }
            break;

        // Taking items
        case "take":
            if (words.Length > 1)
            {
                string itemToTakeName = string.Join(" ", words.Skip(1));
                Item? itemToTake = player.CurrentRoom.ItemsInRoom.Find(item => item.Name.Equals(itemToTakeName, StringComparison.OrdinalIgnoreCase));
                if (itemToTake != null)
                {
                    player.CurrentRoom.ItemsInRoom.Remove(itemToTake);
                    player.Inventory.Add(itemToTake);
                    Console.WriteLine($"You took the {itemToTake.Name}.");
                }
                else
                {
                    Console.WriteLine("That item is not in this room.");
                }
            }
            else
            {
                Console.WriteLine("What do you want to take?");
            }
            break;

        // Open Inventory
        case "inventory":
        case "i":
            if (player.Inventory.Count > 0)
            {
                Console.WriteLine("Inventory: ");
                Console.WriteLine("");

                foreach (Item item in player.Inventory)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Description);
                }
            }
            else
            {
                Console.WriteLine("Inventory is empty!");
            }
            break;

        default:
            Console.WriteLine("I don't understand that command.");
            break;
    }
}