using System.Collections.Generic;
using System.Linq;
using MicroStuff.Sessions.Models;

namespace MicroStuff.Sessions.Data
{
	public interface ISlots
	{
		IEnumerable<Slot> Get();
		Slot Get(int id);
	}
	
    public class Slots : ISlots
	{
		private static readonly Slot[] _slots = {
			new Slot(1, "09:00", "10:00"),
			new Slot(2, "10:15", "11:15"),
			new Slot(3, "11:30", "12:30")
		};
		
		public IEnumerable<Slot> Get()
		{
			return _slots.AsEnumerable();
		}
		
		public Slot Get(int id)
		{
			return _slots.FirstOrDefault(s => s.Id == id);
		}
	}
}