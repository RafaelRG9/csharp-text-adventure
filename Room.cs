public class Room
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Room? North { get; set; }
    public Room? South { get; set; }
    public Room? East { get; set; }
    public Room? West { get; set; }

    // Constructor
    public Room(string name, string description)
    {
        Name = name;
        Description = description;
    }
}