using BOA.User.Source.ResponseAndRequest.Request;
using BOA.User.Source.ResponseAndRequest.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Interfaces.Repos
{
    public interface IRegUserRepos
    {
        List<UserPostResponse> GetPosts(GetPostsRequest req);
        List<ToDoResponse> GetToDo(ToDoRequest req);
        List<AlbumResponse> GetAlbums(GetAlbumRequest req);
    }
}
