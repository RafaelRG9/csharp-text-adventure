public class Room
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Constructor
    public Room(string name, string description)
    {
        Name = name;
        Description = description;
    }
}