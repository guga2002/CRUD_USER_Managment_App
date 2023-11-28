using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Models.Resource
{
    [Table("User_Posts")]
    public class User_Post
    {
        [Key]
        public  int UserPostID { get; set; }
        public string? Tittle { get; set; }
        public string? Body  { get; set; }

        [ForeignKey("user")]
        public int UserID { get; set; }

        public Useri user { get; set; }

        public List<Coment> _coments { get; set; }
    }
}
