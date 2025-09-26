// --- World Creation ---
// Create instances of our Room class
Room startingRoom = new Room("The Entry Hall", "You stand in a grand entry hall. A large wooden door is to the north.");
Room library = new Room("The Library", "You are in a dusty library filled with ancient books. The entry hall is to the south.");

// --- Player Creation ---
// Create a new player and place them in the starting room
Player player = new Player(startingRoom);

// --- Game Logic ---
// For now, we will just describe the player's current location
Console.WriteLine($"You are in: {player.CurrentRoom.Name}");
Console.WriteLine(player.CurrentRoom.Description);