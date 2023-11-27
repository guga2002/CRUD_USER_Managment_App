using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Models
{
    [Table("UserProfiles")]
    public class UserProfile
    {
        [Key]
        public int userProfileID { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
        [StringLength(11)]
        [Required]
        public string PersonalNumber { get; set; }

        [ForeignKey("users")]
        public  string UserID { get; set; }

        public Useri users { get; set; }
    }
}
