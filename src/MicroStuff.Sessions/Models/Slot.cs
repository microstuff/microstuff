using System;

namespace MicroStuff.Sessions.Models
{
    public class Slot
    {
        public Slot()
        {
            
        }
        
        public Slot(int id, string start, string end)
        {
            Id = id;
            Start = TimeSpan.Parse(start);
            End = TimeSpan.Parse(end);
        }
        
		public int Id { get; set; }
        public TimeSpan Start { get; set; }
		public TimeSpan End { get; set; }
    }
}
