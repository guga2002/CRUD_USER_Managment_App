using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.User.Source.ResponseAndRequest.Response
{
    public  class UserViewResponse
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string BS { get; set; }
    }
}
