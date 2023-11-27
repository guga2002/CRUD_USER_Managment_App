using BOA.User.Source.ResponseAndRequest.Request;
using OBA.User.Core.Interfaces;
using OBA.User.Core.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Services
{
    public  class AuthServices:IAuthService
    {
        private readonly IauthRepos repos;

        public AuthServices(IauthRepos rep)
        {
            repos = rep;
        }
       public  async Task<bool> Register(RegisterRequest user)
        {
            return await repos.Register(user);
        }
        public async Task<string> SignIn(SIgnInRequest sign)
        {
            return await repos.SignIn(sign);
        }
    }
}
