using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Models.Resource
{
    [Table("Coments")]
    public class Coment
    {
        [Key]
        public int  ComentID { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }

        [ForeignKey("_posts")]
        public int PostID { get; set; }
        public User_Post _posts { get; set; }

    }
}
