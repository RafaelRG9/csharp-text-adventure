// --- World Creation ---
// Create instances of Room class
Room startingRoom = new Room("The Entry Hall", "You stand in a grand entry hall. A large wooden door is to the north.");
Room library = new Room("The Library", "You are in a dusty library filled with ancient books. The entry hall is to the south.");
startingRoom.North = library;
library.South = startingRoom;

// --- Player Creation ---
// Create a new player and place them in the starting room
Player player = new Player(startingRoom);

// --- Game Logic ---
Console.WriteLine($"You are in: {player.CurrentRoom.Name}");
Console.WriteLine(player.CurrentRoom.Description);

// --- Game Loop ---
while (true)
{
    // Describe the current room at the start of every turn.
    Console.WriteLine($"\nYou are in: {player.CurrentRoom.Name}");
    Console.WriteLine(player.CurrentRoom.Description);

    // Ask for a command
    Console.WriteLine("Where d you want to go?");
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
    else
    {
        Console.WriteLine("Invalid direction. Please enter north, south, east, or west.");
        continue; // Restart the loop
    }
}