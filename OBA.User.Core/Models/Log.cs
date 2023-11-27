using BOA.User.Source.HelperEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Models
{
    [Table("Logs")]
    public  class Log
    {
        [Key]
        public int LogID { get; set; }
        public string text { get; set; }

        public typeEnums type { get; set; }
        public DateTime time { get; set; }
    }
}
