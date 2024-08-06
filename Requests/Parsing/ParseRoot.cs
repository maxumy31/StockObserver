using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockObserver.Requests.Parsing
{
    public class ParseRoot
    {
        public List<string> columns { get; set; } = new List<string>();
        public List<List<object>> data { get; set; } = new List<List<object>>();

        public int FindColumnId(string s)
        {
            string a = columns.Find(x => x == s);
            return columns.IndexOf(a);
        }
        
        public string GetDataByColumnId(int id)
        {
            return data[0][id].ToString();
        }
    }
}
