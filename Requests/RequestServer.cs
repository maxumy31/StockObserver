using StockObserver.Requests.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockObserver.Requests
{
    public class RequestServer
    {
        private static RequestServer _instance;
        public ParseRoot LastRoot { get; private set; }
        public TimeOnly LastUpdateTime { get; private set; } 
        string url = "https://iss.moex.com/iss/engines/stock/markets/index/boards/SNDX/securities/IMOEX.json?iss.meta=off";
        private RequestServer() 
        {
            MakeNewRequest();
        }
        public static RequestServer GetInstance()
        {
            if(_instance == null) _instance = new RequestServer();
            return _instance;
        }

        public void MakeNewRequest()
        {
            RequestHandler handler = new RequestHandler(url);
            RequestParser p = new RequestParser();
            LastRoot = p.Parse(handler.MakeRequest().Result);
            LastUpdateTime = TimeOnly.FromDateTime(DateTime.Now);
        }

    }
}
