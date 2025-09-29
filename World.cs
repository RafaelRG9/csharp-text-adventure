public class World
{
    // List to hold all rooms
    public List<Room> Rooms { get; private set; }

    // Method to create and populate a list of rooms with their connections
    private void CreateWorld()
    {
        //Items
        Item rustyKey = new Item("Rusty Key", "It's an old, heavy iron key, covered in rust.");
        Item glowingPotion = new Item("Glowing Potion", "A small vial filled with a liquid that emits a soft, green light.");
        Item oldSword = new Item("Old Sword", "An old looking sword, looks rusted but suriprinsingly sharp");
        Item dustyTome = new Item("Dusty Tome", "This tome looks worn and covered in dust, but the edge glow with mystical light");
        Item emptyBottle = new Item("Empty Bottle", "An ordinary looking empty flask, looks clean");
        Item fadedShield = new Item("Faded Shield", "Old and sturdy, the family emblem is barely visible");
        Item oldArmor = new Item("Old Armor", "Battle worn piece of heavy armor, it as seen better days but can still hold up");
        Item manorMap = new Item("Manor Map", "A Map of the Manor, detailing all the different rooms and some secret passages");

        //Rooms
        Room entryHall = new Room("The Entry Hall",
                                    "You stand in a grand entry hall. A large wooden door is to the north. A steel damp door to the east");
        Room library = new Room("The Library",
                                "You are in a dusty library filled with ancient books. A large wooden door is to the south. a medium rusted door to the east");
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

        //Add Items to the rooms
        alchemyLab.ItemsInRoom.Add(glowingPotion);
        alchemyLab.ItemsInRoom.Add(emptyBottle);
        dustyArmory.ItemsInRoom.Add(oldSword);
        dustyArmory.ItemsInRoom.Add(fadedShield);
        dustyArmory.ItemsInRoom.Add(oldArmor);
        library.ItemsInRoom.Add(rustyKey);
        library.ItemsInRoom.Add(dustyTome);
        library.ItemsInRoom.Add(manorMap);
    }

    // Constructor
    public World()
    {
        Rooms = new List<Room>();
        CreateWorld();
    }
}