namespace MicroStuff.Sessions.Models
{
    public class Room
    {
        public Room()
        {
            
        }
        
        public Room(string name)
        {
            Name = name;
            Id = name.ToLower();
        }
        
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
