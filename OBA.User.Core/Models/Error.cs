using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using BOA.User.Source.HelperEnum;

namespace OBA.User.Core.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int ErrorID { get; set; }

        public string text { get; set; }

        public typeEnums type { get; set; }
        public DateTime time { get; set; }
    }
}
