namespace MicroStuff.Sessions.Models
{
    public class Session
    {
        public Session()
        {
        }

        public Session(Slot slot, Room room, Speaker speaker, string title)
        {
            Slot = slot;
            Room = room;
            Speaker = speaker;
            Title = title;
        }
        
        public Slot Slot { get; set; }
        
        public Room Room { get; set; }
        
        public Speaker Speaker { get; set; }

        public string Title { get; set; }
    }
}
