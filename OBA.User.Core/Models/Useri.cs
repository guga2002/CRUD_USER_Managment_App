
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OBA.User.Core.Models
{
    [Table("Users")]
    public class Useri:IdentityUser
    {
      //identityshi aris yvela sachiro veli
        public bool IsActive { get; set; }
        [Required]
        public int UserIdentifier { get; set; }
        public DateTime action { get; set; }
        public UserProfile _profiles { get; set; }
    }
}
