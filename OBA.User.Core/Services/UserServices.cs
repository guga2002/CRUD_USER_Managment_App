using BOA.User.Source.ResponseAndRequest.Request;
using BOA.User.Source.ResponseAndRequest.Response;
using OBA.User.Core.Interfaces;
using OBA.User.Core.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IuserRepos rep;
        public UserServices(IuserRepos rep)
        {
            this.rep = rep;  
        }
        public bool EditProfile(EditRequest req)
        {
            return rep.EditProfile(req);
        }

        public bool PermanentlyDelete(PermanentlyDeleteRequest req)
        {
            return rep.PermanentlyDelete(req);
        }

        public Task<bool> Register(RegisterRequest user)
        {
            return rep.Register(user);
        }

        public bool SoftDelete(SoftDeleteReqest req)
        {
            return rep.SoftDelete(req);
        }

        public UserViewResponse ViewProfile(ViewProfileRequest req)
        {
            return rep.ViewProfile(req);
        }
    }
}
