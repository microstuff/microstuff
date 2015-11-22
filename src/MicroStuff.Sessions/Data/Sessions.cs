using System.Collections.Generic;
using MicroStuff.Sessions.Models;

namespace MicroStuff.Sessions.Data
{
    public interface ISessions
    {
        IEnumerable<Session> Get();
    }
    
    public class Sessions : ISessions
    {
        private readonly IRooms _rooms;
        private readonly ISlots _slots;
        private readonly ISpeakers _speakers;

        public Sessions(ISlots slots, IRooms rooms, ISpeakers speakers)
        {
            _slots = slots;
            _rooms = rooms;
            _speakers = speakers;
        }
        
        public IEnumerable<Session> Get()
        {
            var slot1 = _slots.Get(1);
            var slot2 = _slots.Get(2);
            var slot3 = _slots.Get(3);
            
            var alfa = _rooms.Get("alfa");
            var beta = _rooms.Get("beta");
            
            yield return new Session(slot1, alfa, _speakers.Get("mark_rendle"), "ASP.NET Stuff");
            yield return new Session(slot1, beta, _speakers.Get("greg_young"), "CQRS and DDD Stuff");

            yield return new Session(slot2, alfa, _speakers.Get("bob_martin"), "Things about programming");
            yield return new Session(slot2, beta, _speakers.Get("rachel_reese"), "F# is great");

            yield return new Session(slot3, alfa, _speakers.Get("rob_ashton"), "Erlang is better");
            yield return new Session(slot3, beta, _speakers.Get("ian_cooper"), ".NET FTW");
        }
    }
}
