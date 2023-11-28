using BOA.User.Source.ResponseAndRequest.Request;
using BOA.User.Source.ResponseAndRequest.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Interfaces.Repos
{
    public  interface IuserRepos
    {
        Task<bool> Register(RegisterRequest user);
        UserViewResponse ViewProfile(ViewProfileRequest req);
        bool EditProfile(EditRequest req);
        bool SoftDelete(SoftDeleteReqest req);
        bool PermanentlyDelete(PermanentlyDeleteRequest req);

    }
}
