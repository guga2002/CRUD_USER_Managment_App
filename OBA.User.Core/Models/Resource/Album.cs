using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Models.Resource
{
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        public string Title { get; set; }

        [ForeignKey("_user")]
        public int UserID { get; set; }
        public Useri _user { get; set; }

        public List<Photo> _photos { get; set; }
    }
}
