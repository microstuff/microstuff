using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MicroStuff.Models;
using Newtonsoft.Json;

namespace MicroStuff.Data
{
    public interface ISessions
    {
        Task<IList<Session>> Get();
    }
    
    public class Sessions : ISessions
    {
        private readonly HttpClient _client;
        private readonly string _sessionsUri;
        
        public Sessions()
        {
            _client = new HttpClient();
            
            var sessionsTcp = Startup.Configuration["SESSIONS_PORT"];
            if (!string.IsNullOrWhiteSpace(sessionsTcp))
            {
                _sessionsUri = $"http{sessionsTcp.Substring(3)}/sessions/";
            }
            else
            {
                _sessionsUri = "http://localhost:5001/sessions/";
            }
        }

        public async Task<IList<Session>> Get()
        {
            var json = await _client.GetStringAsync(_sessionsUri);
            return JsonConvert.DeserializeObject<List<Session>>(json);
        }
    }
}
