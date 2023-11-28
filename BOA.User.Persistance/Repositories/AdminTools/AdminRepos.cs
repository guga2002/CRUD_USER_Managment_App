using BOA.User.Source.JsonDeserializing;
using BOA.User.Source.ResponseAndRequest.Request;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Core.Models;
using OBA.User.Core.Models.Resource;
using OBA.User.Infrastructure.Data.DbContexti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BOA.User.Persistance.Repositories.AdminTools
{
    public class AdminRepos : IAdminRepos
    {
        private readonly AppDbContext db;
        private readonly IuserRepos rep;

        public AdminRepos(AppDbContext db, IuserRepos re)
        {
            this.db = db;
            rep = re;
        }
        #region InicializeUserInBase
        public async Task InicializeUSersAsync()
        {
            string apiUrl = "https://jsonplaceholder.typicode.com/users";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        var users = JsonConvert.DeserializeObject<JsonUser[]>(jsonContent);
                        List<RegisterRequest> reqies = new List<RegisterRequest>();

                        foreach (var user in users)
                        {
                            var phon = "";
                            foreach (var item in user.phone)
                            {
                                if (char.IsDigit(item))
                                {
                                    phon += item;
                                }
                            }
                            string[] mas = user.name.Split(' ', '_', '.', '-');
                            Random rnd = new Random();
                            string prtsonal = "2600107" + rnd.Next(1000, 9999).ToString();
                            RegisterRequest req = new RegisterRequest()
                            {
                                city = user.address.city,
                                BS = user.company.bs,
                                Role = "USER",
                                Email = user.email,
                                street = user.address.street,
                                suite = user.address.suite,
                                CatchPhrase = user.company.catchPhrase,
                                Firstname = mas[0],
                                Lastname = mas[1],
                                NameofCompanie = user.company.name,
                                PersonalNumber = prtsonal,
                                zipcode = user.address.zipcode,
                                Phone = phon,
                                Username = user.username,
                                Password = "Guga2002Guga",
                            };

                            reqies.Add(req);
                        }

                        foreach (var item in reqies)
                        {
                            await rep.Register(item);

                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region InicializeToDo
        public bool InicializeToDo(inicializetodoRequest UserID)
        {
            if (!db.Users.Any(io => io.Id == UserID.UderID)) return false;
            string apiUrl = "https://jsonplaceholder.typicode.com/todos";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        var ToDos = JsonConvert.DeserializeObject<JsonTOdo[]>(jsonContent);


                        foreach (var todo in ToDos.Where(io => io.userId == UserID.UderID))
                        {
                            if (!db.Todos.Any(io => io.UserID == UserID.UderID && io.title == todo.title))
                            {
                                db.Todos.Add(new OBA.User.Core.Models.Resource.ToDo()
                                {
                                    title = todo.title,
                                    UserID = todo.userId,
                                    IScomplete = todo.completed,
                                });
                                db.SaveChanges();
                            }
                            else
                            {
                                //msgavsi  todoukve arsebobda da agar davamatet siashi
                                continue;
                            }
                        }
                        return true;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                }
                return false;
            }
        }
        #endregion

        #region InicializeAlbum

        public bool InicializeAlbum(AlbumInicializeRequest req)
        {
            if (!db.Users.Any(io => io.Id == req.UserID)) return false;
            string apiUrl = "https://jsonplaceholder.typicode.com/albums";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        var albums = JsonConvert.DeserializeObject<JsonAlbum[]>(jsonContent);


                        foreach (var album in albums.Where(io => io.userId == req.UserID))
                        {
                            if (!db.Albums.Any(io => io.UserID == req.UserID && io.Title == album.title))
                            {
                                db.Albums.Add(new OBA.User.Core.Models.Resource.Album()
                                {
                                    Title = album.title,
                                    UserID = album.userId,
                                });
                                db.SaveChanges();
                            }
                            else
                            {
                                //msgavsi  albomi arsebobda da agar davamatet siashi
                                continue;
                            }
                        }
                        return true;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                }
                return false;
            }
        }
        #endregion

        #region InicializePhotos
        public bool InicializePictures(InicializePicturesRequest req)
        {
            if (!db.Users.Any(io => io.Id == req.UserID)) return false;
            var listofalbums = db.Albums.Where(io => io.UserID == req.UserID).Select(io => io.AlbumID).ToList();
           
            string apiUrl = "https://jsonplaceholder.typicode.com/photos";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        var photo = JsonConvert.DeserializeObject<JsonPhotos[]>(jsonContent);
                      
                        foreach (var album in listofalbums)
                        {
                           var lst= photo.Where(io => io.albumId==album).ToList();
                           
                            foreach (var phot in lst)
                            {
                                if (!db.Photos.Any(io => io.AlbumID == album && io.Tittle == phot.title))
                                {
                                    db.Photos.Add(new OBA.User.Core.Models.Resource.Photo()
                                    {
                                        Tittle = phot.title,
                                        thumbnailUrl = phot.thumbnailUrl,
                                        URL = phot.url,
                                        AlbumID = album
                                    });
                                    db.SaveChanges();
                                }
                                else
                                {
                                    //msgavsi  albomi arsebobda da agar davamatet siashi
                                    continue;
                                }
                            }
                        }
                    
                        return true;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                }
                return false;
            }
        }
        #endregion

        #region InicializePosts
        public bool InicializePosts(InicializePostRequest req)
        {
            if (!db.Users.Any(io => io.Id == req.UserID)) return false;
           
            string apiUrl = "https://jsonplaceholder.typicode.com/posts";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        var posts = JsonConvert.DeserializeObject<JsonPost[]>(jsonContent);

                            foreach (var post in posts.Where(io=>io.userId==req.UserID).ToList())
                            {
                                if (!db.Posts.Any(io => io.UserID == req.UserID && io.Tittle == post.title))
                                {
                                    db.Posts.Add(new OBA.User.Core.Models.Resource.User_Post()
                                    {
                                     Body=post.body,
                                     Tittle=post.title,
                                     UserID=req.UserID,
                                    });
                                    db.SaveChanges();
                                }
                                else
                                {
                                    //msgavsi  albomi arsebobda da agar davamatet siashi
                                    continue;
                                }
                            }

                        return true;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                }
                return false;
            }

        }

        #endregion

        #region Inicialize Comentars
        public bool InicializeCOmentars(InicializeCOmentarsRequest req)
        {
            if (!db.Users.Any(io => io.Id == req.UserID)) return false;
            var listopposts = db.Posts.Where(io => io.UserID == req.UserID).Select(io => io.UserPostID).ToList();

            string apiUrl = "https://jsonplaceholder.typicode.com/comments";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        var coments = JsonConvert.DeserializeObject<JsonComents[]>(jsonContent);

                        foreach (var post in listopposts)
                        {
                            var lst = coments.Where(io => io.postId == post).ToList();

                            foreach (var com in lst)
                            {
                                if (!db.Comments.Any(io => io.PostID == post && io.Name == com.name))
                                {
                                    db.Comments.Add(new OBA.User.Core.Models.Resource.Coment()
                                    {
                                       Body=com.body,
                                       Email=com.email,
                                       Name=com.name,
                                       PostID=post
                                     ,
                                    });
                                    db.SaveChanges();
                                }
                                else
                                {
                                    //msgavsi  albomi arsebobda da agar davamatet siashi
                                    continue;
                                }
                            }
                        }

                        return true;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                }
                return false;
            }
        }
        #endregion
    }
}
