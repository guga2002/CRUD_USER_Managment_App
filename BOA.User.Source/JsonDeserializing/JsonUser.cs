using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BOA.User.Source.JsonDeserializing
{
    public class JsonUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Jsonaddress address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public JsonCompany company { get; set; }
    }
}
