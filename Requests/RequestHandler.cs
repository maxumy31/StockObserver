using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockObserver.Requests
{

    public class RequestHandler
    {
        string url;
        HttpClient http;

        public RequestHandler(string url)
        {
            this.url = url;
            http = new()
            {
                BaseAddress = new Uri(url),
            };
        }

        public async Task<string> MakeRequest()
        {
            HttpResponseMessage response = await http.GetAsync(url);
            var jsonResponse = await response.Content.ReadAsStringAsync();


            return $"{jsonResponse}\n";
        }
    }
}
