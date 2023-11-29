using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.User.Source.ResponseAndRequest.Response
{
    public class UserPostResponse
    {
        public string Tittle { get; set; }
        public string Body { get; set; }

        public List<ComentsResponse> coments { get; set; }=new List<ComentsResponse>() { };
    }
}
