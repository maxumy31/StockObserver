using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockObserver.Requests.Parsing
{
    public class RequestParser
    {
        public ParseRoot Parse(string input)
        {
            string s = input;
            return ParseString(input);
        }

        private ParseRoot ParseString(string data)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            int marketDataId = data.IndexOf("marketdata");
            int dataVersionID = data.IndexOf("dataversion");
            if (marketDataId == -1) { Console.WriteLine("ERROR REQUEST!!!"); }

            int frontPadding = 13;
            int backPadding = 3 + frontPadding;
            data = data.Substring(marketDataId + frontPadding, dataVersionID - marketDataId - backPadding);
            ParseRoot? parsedRoot = JsonSerializer.Deserialize<ParseRoot>(data);


            return parsedRoot;
        }
    }
}
