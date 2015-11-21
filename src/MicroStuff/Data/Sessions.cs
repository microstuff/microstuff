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
        private readonly IConsulClient _consulClient;

        public Sessions(IConsulClient consulClient)
        {
            _consulClient = consulClient;
            _client = new HttpClient();
        }

        public async Task<IList<Session>> Get()
        {
            var services = await _consulClient.FindAsync("sessions");
            if (services == null)
            {
                return new Session[0];
            }
            var service = services.FirstOrDefault();
            var json = await _client.GetStringAsync($"http://{service.ServiceAddress}:{service.ServicePort}/sessions");
            return JsonConvert.DeserializeObject<List<Session>>(json);
        }
    }
}
