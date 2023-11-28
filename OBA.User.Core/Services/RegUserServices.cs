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
    public class RegUserServices : IregUserServices
    {
        private readonly IRegUserRepos rep;

        public RegUserServices(IRegUserRepos re)
        {
            rep = re;
        }
        public List<AlbumResponse> GetAlbums(GetAlbumRequest req)
        {
            return rep.GetAlbums(req) ;
        }

        public List<UserPostResponse> GetPosts(GetPostsRequest req)
        {
            return rep.GetPosts(req);
        }
        public List<ToDoResponse> GetToDo(ToDoRequest req)
        {
            return rep.GetToDo(req);
        }
    }
}
