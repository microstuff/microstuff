using System;

namespace MicroStuff.Models
{
    public class Speaker
    {
        public Speaker()
        {
        }
        
        public Speaker(string name)
        {
            Name = name;
            Id = name.ToLowerInvariant().Replace(' ', '_');
        }
        
        public string Id { get; set; }
        
        public string Name { get; set; }
    }
}
