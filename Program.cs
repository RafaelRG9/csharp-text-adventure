// --- World Creation ---
World gameWorld = new World();

// --- Player Creation ---
// Create a new player and place them in the starting room
Player player = new Player(gameWorld.Rooms[0]);
DescribeRoom(player);

// --- Game Loop ---
while (true)
{
    // Ask for a command
    Console.WriteLine("Where do you go or what do you do?");
    Console.Write("> ");

    // Read and split input to extract commands
    var playerAction = Console.ReadLine();

    if (string.IsNullOrEmpty(playerAction))
    {
        Console.WriteLine("Please enter a command.");
        Console.WriteLine("> ");
        continue;
    }
    string[] words = playerAction.ToLower().Split(' ');
    string verb = words[0];

    // Commands
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
                        DescribeRoom(player);
                    }
                    else
                    {
                        Console.WriteLine("There is no exit to the north.");
                        Console.WriteLine("");
                    }
                    break;
                case "south":
                    if (player.CurrentRoom.South != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.South;
                        DescribeRoom(player);
                    }
                    else
                    {
                        Console.WriteLine("There is no exit to the south.");
                        Console.WriteLine("");
                    }
                    break;
                case "east":
                    if (player.CurrentRoom.Name == "The Entry Hall")
                    {
                        if (!player.Inventory.Any(item => item.Name == "Rusty Key"))
                        {
                            Console.WriteLine("The door to the east is locked.");
                            break;
                        }
                        Console.WriteLine("You unlock the door with the rusty key and step outside.");
                    }
                    if (player.CurrentRoom.East != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.East;
                        DescribeRoom(player);
                        if (player.CurrentRoom.Name == "Courtyard")
                        {
                            Console.WriteLine("\nCongratulations, you have escaped the manor!");
                            Environment.Exit(0); // THIS ENDS THE GAME!
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no exit to the east.");
                        Console.WriteLine("");
                    }
                    break;
                case "west":
                    if (player.CurrentRoom.West != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.West;
                        DescribeRoom(player);
                    }
                    else
                    {
                        Console.WriteLine("There is no exit to the west.");
                        Console.WriteLine("");
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
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("That item is not in this room.");
                    Console.WriteLine("");
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
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Inventory is empty!");
                Console.WriteLine("");
            }
            break;

        // Look Command
        case "look":
        case "l":
            DescribeRoom(player);
            break;

        // Drop Command
        case "drop":
            if (words.Length > 1)
            {
                string itemToDropName = string.Join(" ", words.Skip(1));
                Item? itemToDrop = player.Inventory.Find(item => item.Name.Equals(itemToDropName, StringComparison.OrdinalIgnoreCase));
                if (itemToDrop != null)
                {
                    player.Inventory.Remove(itemToDrop);
                    player.CurrentRoom.ItemsInRoom.Add(itemToDrop);
                    Console.WriteLine($"You dropped: {itemToDrop.Name}.");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("That item is not in your inventory.");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("What do you want to drop?");
            }
            break;

        default:
            Console.WriteLine("I don't understand that command.");
            break;

        
    }
}

void DescribeRoom(Player player)
{
    Console.WriteLine($"\nYou are in: {player.CurrentRoom.Name}");
    Console.WriteLine(player.CurrentRoom.Description);

    // Check for items in the room
    if (player.CurrentRoom.ItemsInRoom.Count > 0)
    {
        Console.WriteLine("After carefully inspecting the room you find:");
        foreach (Item item in player.CurrentRoom.ItemsInRoom)
        {
            Console.WriteLine($"- {item.Name}");
        }
        Console.WriteLine("");
    }
}