using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int CompanieID { get; set; }

        public string? Name { get; set; }

        public string? CatchPhrase { get; set; }

        public string?  BS { get; set; }

        public UserProfile userprof { get; set; }
    }
}
