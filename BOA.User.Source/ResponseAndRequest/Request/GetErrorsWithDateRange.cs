using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.User.Source.ResponseAndRequest.Request
{
    public class GetErrorsWithDateRange
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
