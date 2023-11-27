using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOA.User.Source.ResponseAndRequest.Request
{
    public  class RegisterRequest
    {
       
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }

    }
}
