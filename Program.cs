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
    Console.WriteLine("Where do you want to go?");
    Console.Write("> ");

    // Read and validate the user's input
    var playerAction = Console.ReadLine();

    // Check for a valid input
    if (string.IsNullOrEmpty(playerAction))
    {
        Console.WriteLine("Please enter a direction.");
        continue; // Restart the loop
    }

    if (playerAction.Equals("north", StringComparison.OrdinalIgnoreCase) ||
        playerAction.Equals("south", StringComparison.OrdinalIgnoreCase) ||
        playerAction.Equals("east", StringComparison.OrdinalIgnoreCase) ||
        playerAction.Equals("west", StringComparison.OrdinalIgnoreCase))
    {
        // Move player based on choice
        switch (playerAction.ToLower())
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
    }
    else if (playerAction.StartsWith("take ", StringComparison.OrdinalIgnoreCase))
    {
        string itemToTakeName = playerAction.Substring(5);
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
        Console.WriteLine("Invalid direction. Please enter north, south, east, or west.");
        continue; // Restart the loop.
    }
}