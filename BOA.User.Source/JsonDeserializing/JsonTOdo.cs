using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.User.Source.JsonDeserializing
{
    public  class JsonTOdo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public  string title { get; set; }
        public bool completed { get; set; }
    }
}
