using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.User.Source.ResponseAndRequest.Request
{
    public class EditRequest
    {
        public string PersonalNumber { get; set; }
        public string? Firstname { get; set; }
        public string ?Lastname { get; set; }
        public string? street { get; set; }
        public string? suite { get; set; }
        public string? zipcode { get; set; }
        public string? city { get; set; }
        public string? NameOfcompany { get; set; }
        public string? CatchPhrase { get; set; }
        public string? BS { get; set; }
    }
}
