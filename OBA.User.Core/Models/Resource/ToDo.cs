using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Models.Resource
{

    [Table("ToDos")]
    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }
        public string?title { get; set; }

        public bool IScomplete { get; set; }

        [ForeignKey("user")]
        public int UserID { get; set; }

        public Useri user { get; set; }
    }
}
