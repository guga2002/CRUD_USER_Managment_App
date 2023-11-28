using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Infrastructure.Data.DbContexti
{
    public class Identityroleb : IdentityRole<int>
    {

        public Identityroleb(string code) : base(code)
        {
            
        }

        public Identityroleb()
        {
                
        }

    }
}
