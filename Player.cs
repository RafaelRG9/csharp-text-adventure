public class Player
{
    public Room CurrentRoom { get; set; }

    // Constructor
    public Player(Room startingRoom)
    {
        CurrentRoom = startingRoom;
    }
}