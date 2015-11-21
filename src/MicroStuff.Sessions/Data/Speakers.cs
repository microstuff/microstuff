using System;
using System.Collections.Generic;
using System.Linq;
using MicroStuff.Sessions.Models;

namespace MicroStuff.Sessions.Data
{
    public interface ISpeakers
    {
        IEnumerable<Speaker> Get();
        Speaker Get(string id);
    }
    
    public class Speakers : ISpeakers
    {
        private static readonly Speaker[] _speakers = {
            new Speaker("Mark Rendle"),
            new Speaker("Greg Young"),
            new Speaker("Bob Martin"),
            new Speaker("Rachel Reese"),
            new Speaker("Rob Ashton"),
            new Speaker("Ian Cooper")
        };
        
        public IEnumerable<Speaker> Get()
        {
            return _speakers.AsEnumerable();
        }
        
        public Speaker Get(string id)
        {
            var speaker = _speakers.FirstOrDefault(s => s.Id == id);
            if (speaker != null)
            {
                Console.WriteLine(speaker.Name);
            }
            else
            {
                Console.WriteLine("No speaker found");
            }
            return speaker;
        }
    }
}
