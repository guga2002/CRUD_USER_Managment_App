using BOA.User.Source.ResponseAndRequest.Request;
using BOA.User.Source.ResponseAndRequest.Response;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Infrastructure.Data.DbContexti;
namespace BOA.User.Persistance.Repositories.UserResourcesManage
{
    public  class ManageResourcesRepos: IRegUserRepos
    {
        private readonly AppDbContext _db;
        private readonly IerrorRepos error;
        private readonly ILogRepos logger;

        public ManageResourcesRepos(AppDbContext db, IerrorRepos error, ILogRepos logger)
        {
            _db = db;
            this.error = error;
            this.logger = logger;
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
                    Console.WriteLine("guga");
                    var filtercoments = _db.Comments.Where(io => io.PostID == post.UserPostID).ToList();

                    foreach (var item in filtercoments)
                    {
                        var temp = new ComentsResponse()
                        {
                            Email = item.Email,
                            Body = item.Body,
                            Name = item.Name,
                        };
                        response.coments.Add(temp);
                    }

                    response.Body = post.Body;
                    response.Tittle = post.Tittle;

                    resp.Add(response);
                }
                logger.Action("successfully get Users Posts and coments", Source.HelperEnum.typeEnums.Easy);
                return resp;

            }
            catch (Exception exp)
            {
                error.Action(exp.Message, Source.HelperEnum.typeEnums.Easy);
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
                logger.Action("Succesfully got users todo", Source.HelperEnum.typeEnums.debbuging);
                return result;

            }
            catch (Exception exp)
            {
                error.Action(exp.Message, Source.HelperEnum.typeEnums.Easy);
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
                    var filterphot = _db.Photos.Where(io => io.AlbumID == album.AlbumID).Select(io =>
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
                logger.Action("GEt Users albums and pictures sucesfully",Source.HelperEnum.typeEnums.info);
                return result;

            }
            catch (Exception exp)
            {
                error.Action(exp.Message, Source.HelperEnum.typeEnums.Easy);
                throw exp;
            }
        }
        #endregion
    }
}
