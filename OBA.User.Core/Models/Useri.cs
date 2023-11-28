
using Microsoft.AspNetCore.Identity;
using OBA.User.Core.Models.Resource;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OBA.User.Core.Models
{
    [Table("Users")]
    public class Useri:IdentityUser<int>
    {
        //identityshi aris yvela sachiro veli
        [Key]
        override
        public int Id { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public DateTime action { get; set; }

        [ForeignKey("_profiles")]
        public int ProfileID { get; set; }
        public UserProfile _profiles { get; set; }

        public List<ToDo> _todos { get; set; }

        public List<Album> _albums { get; set; }

        public List<User_Post> _Posts { get; set; }


    }
}
