using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroStuff.Sessions
{
    public class ConsulClient
    {
        private readonly string _consul;

        public ConsulClient(string consul)
        {
            _consul = consul.TrimEnd('/');
        }
        
        public async Task<bool> Register(string name, int port)
        {
            var hostEntry = await Dns.GetHostEntryAsync("");
            var ip = hostEntry.AddressList.FirstOrDefault()?.ToString();
            if (string.IsNullOrWhiteSpace(ip))
            {
                return false;
            }
            using (var client = new HttpClient())
            {
                int retries = 3;
                while (retries-- > 0)
                {
                    var res = await client.PostAsync(_consul + "/v1/agent/service/register", new StringContent(MakeRegisterEntry(name, ip, port)));
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                    await Task.Delay(1000);
                }
            }
            return false;
        }
        
        private static string MakeRegisterEntry(string name, string ip, int port)
        {
            return $"{{ \"Name\": \"{name}\", \"Address\": \"{ip}\", \"Port\": {port} }}";
        }
    }
}
