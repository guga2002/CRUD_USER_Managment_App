using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Models.Resource
{
    [Table("Photos")]
    public class Photo
    {
        [Key]
        public int PhotoID { get; set; }
        public string Tittle { get; set; }
        public string URL { get; set; }
        public string thumbnailUrl { get; set; }

        [ForeignKey("_album")]
        public  int AlbumID { get; set; }
        public Album _album { get; set; }
    }
}
