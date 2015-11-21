using System;

namespace MicroStuff.Models
{
    public class Slot : IEquatable<Slot>
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

        public bool Equals(Slot other) => other?.Id == Id;
        
        public override bool Equals (object obj)
        {
            return Equals(obj as Slot);
        }
        
        public override int GetHashCode()
        {
            return Id;
        }
        
    }
}
