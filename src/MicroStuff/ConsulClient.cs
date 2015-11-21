using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MicroStuff
{
    public interface IConsulClient
    {
        Task<IList<ConsulService>> FindAsync(string name);
    }
    public class ConsulClient : IConsulClient
    {
        private readonly string _consul;

        public ConsulClient(string consul)
        {
            if (consul != null)
            {
                _consul = consul.TrimEnd('/');
            }
        }
        
        public async Task<IList<ConsulService>> FindAsync(string name)
        {
            if (_consul == null)
            {
                return null;
            }
            using (var client = new HttpClient())
            {
                int retries = 3;
                while (retries-- > 0)
                {
                    var res = await client.GetAsync($"{_consul}/v1/catalog/service/{name}");
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        var json = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ConsulService[]>(json);
                    }
                    await Task.Delay(1000);
                }
            }
            return null;
        }
        
        private static string MakeRegisterEntry(string name, string ip, int port)
        {
            return $"{{ \"Name\": \"{name}\", \"Address\": \"{ip}\", \"Port\": {port} }}";
        }
    }
    
    public class ConsulService
    {
        public string ServiceAddress { get; set; }
        public int ServicePort { get; set; }
    }
}
