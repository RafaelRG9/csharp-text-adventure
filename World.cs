public class World
{
    // List to hold all rooms
    public List<Room> Rooms { get; private set; }

    // Method to create and populate a list of rooms with their connections
    private void CreateWorld()
    {
        //Rooms
        Room entryHall = new Room("The Entry Hall",
                                    "You stand in a grand entry hall. A large wooden door is to the north.");
        Room library = new Room("The Library",
                                "You are in a dusty library filled with ancient books. The entry hall is to the south.");
        Room dustyArmory = new Room("The Dusty Armory",
                                    "This small, stone chamber is thick with the smell of rust and ancient dust. Sunken armor stands lean against the walls, their surfaces coated in a fine grey powder. Racks that once held spears and swords are now mostly empty, draped in thick cobwebs. A sturdy wooden door leads west, and another to the south.");
        Room alchemyLab = new Room("The Alchemy Lab",
                                    "The air here hums with a low bubbling sound and smells sharply of strange herbs and ozone. Cluttered tables are covered with glass beakers, twisted distillation tubes, and bubbling vials of glowing liquid. A large, leather-bound book lies open on a lectern, its pages covered in cryptic symbols and astronomical charts. Doors are visible to the north and west.");

        // Rooms connections
        entryHall.North = library;
        entryHall.East = alchemyLab;
        library.South = entryHall;
        library.East = dustyArmory;
        alchemyLab.West = entryHall;
        alchemyLab.North = dustyArmory;
        dustyArmory.West = library;
        dustyArmory.South = alchemyLab;

        // Add Rooms to the list of rooms
        Rooms.Add(entryHall);
        Rooms.Add(library);
        Rooms.Add(alchemyLab);
        Rooms.Add(dustyArmory);
    }

    // Constructor
    public World()
    {
        Rooms = new List<Room>();
        CreateWorld();
    }
}