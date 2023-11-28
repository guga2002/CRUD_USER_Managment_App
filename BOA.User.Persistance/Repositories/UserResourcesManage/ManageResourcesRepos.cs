using BOA.User.Source.ResponseAndRequest.Request;
using BOA.User.Source.ResponseAndRequest.Response;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Infrastructure.Data.DbContexti;
namespace BOA.User.Persistance.Repositories.UserResourcesManage
{
    public  class ManageResourcesRepos: IRegUserRepos
    {
        private readonly AppDbContext _db;

        public ManageResourcesRepos(AppDbContext db)
        {
            _db = db;
        }
        #region GetPosts
        public List<UserPostResponse> GetPosts(GetPostsRequest req)
        {
            try
            {
                List<UserPostResponse> resp = new List<UserPostResponse>();
                var posts = _db.Posts.Where(io => io.UserID == req.UserID).ToList();

                foreach (var post in posts)
                {
                    var response = new UserPostResponse();
                    response.coments = new List<ComentsResponse>();

                    var filtercoments = post._coments.Where(io => io.PostID == post.UserPostID).Select(io =>
                    new ComentsResponse()
                    {
                        Email = io.Email,
                        Body = io.Body,
                        Name = io.Name
                    }).ToList();
                    response.coments.AddRange(filtercoments);
                    response.Body = post.Body;
                    response.Tittle = post.Tittle;

                    resp.Add(response);
                }
                return resp;

            }
            catch (Exception exp)
            {

                throw exp;
            }
        }
        #endregion

        #region GetToDo
        public List<ToDoResponse> GetToDo(ToDoRequest req)
        {
            try
            {
                List<ToDoResponse> result = new List<ToDoResponse>();
                var todos = _db.Todos.Where(io => io.UserID == req.UserID).ToList();

                foreach (var todo in todos)
                {
                    var iter = new ToDoResponse();
                    iter.title = todo.title;
                    iter.IScomplete = todo.IScomplete;
                    result.Add(iter);
                }
                return result;

            }
            catch (Exception exp)
            {

                throw exp;
            }
        }
        #endregion

        #region GetAlbums
        public List<AlbumResponse> GetAlbums(GetAlbumRequest req)
        {
            try
            {
                List<AlbumResponse> result = new List<AlbumResponse>();

                var albumms = _db.Albums.Where(re => re.UserID == req.UserID).ToList();

                foreach (var album in albumms)
                {
                    var iter = new AlbumResponse();
                    iter.Title = album.Title;
                    var filterphot = album._photos.Where(io => io.AlbumID == album.AlbumID).Select(io =>
                    new PhotoResponse()
                    {
                        Tittle = io.Tittle,
                        thumbnailUrl = io.thumbnailUrl,
                        URL = io.URL,
                    }).ToList();
                    iter.photos = new List<PhotoResponse>();
                    iter.photos.AddRange(filterphot);
                    result.Add(iter);
                }
                return result;

            }
            catch (Exception exp)
            {

                throw exp;
            }
        }
        #endregion
    }
}
