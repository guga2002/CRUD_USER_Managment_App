using BOA.User.Source.ResponseAndRequest.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Interfaces.Repos
{
    public  interface IauthRepos
    {
        Task<string> SignIn(SIgnInRequest sign);

    }
}
