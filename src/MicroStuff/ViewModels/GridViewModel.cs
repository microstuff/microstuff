using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroStuff.Models;

namespace MicroStuff.ViewModels
{
    public class GridViewModel
    {
        public GridViewModel(IEnumerable<Session> sessions)
        {
            Rows = new List<Row>();
            
            foreach (var grp in sessions.GroupBy(s => s.Slot))
            {
                Rows.Add(new Row { Slot = grp.Key, Sessions = grp.OrderBy(s => s.Room.Id).ToArray() });
            }
        }
        
        public List<Row> Rows { get; }
        
        public class Row
        {
            public Slot Slot { get; set; }
            public Session[] Sessions { get; set; }
        }
    }
}
