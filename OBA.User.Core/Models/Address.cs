using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Models
{
    [Table("Addresses")]
    public  class Address
    {
        [Key]
        public  int AddressID { get; set; }
        public string? street { get; set; }
        public string? suite { get; set; }
        public string? zipcode { get; set; }
        public string? city { get; set; }

        public UserProfile userprof { get; set; }
    }
}
