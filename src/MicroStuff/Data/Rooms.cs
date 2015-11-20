using System;
using System.Collections.Generic;
using System.Linq;
using MicroStuff.Models;

namespace MicroStuff.Data
{
    public interface IRooms
    {
        IEnumerable<Room> Get();
        
        Room Get(string id);
        
    }
    
    public class Rooms : IRooms
    {
        private static readonly Room[] _rooms = {
            new Room("Alfa"),
            new Room("Beta")
        };
        
        public IEnumerable<Room> Get()
        {
            return _rooms.AsEnumerable();
        }
        
        public Room Get(string id)
        {
            return _rooms.FirstOrDefault(r => r.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }
    }
}
