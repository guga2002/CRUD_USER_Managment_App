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
    public class AdminServices : IAdminService
    {
        private readonly IAdminRepos rep;

        public AdminServices(IAdminRepos er)
        {
            rep = er;
        }

        public bool InicializeAlbum(AlbumInicializeRequest req)
        {
            return rep.InicializeAlbum(req);
        }

        public bool InicializeCOmentars(InicializeCOmentarsRequest req)
        {
            return rep.InicializeCOmentars(req);
        }

        public bool InicializePictures(InicializePicturesRequest req)
        {
            return rep.InicializePictures(req);
        }

        public bool InicializePosts(InicializePostRequest req)
        {
            return rep.InicializePosts(req);
        }

        public bool InicializeToDo(inicializetodoRequest UserID)
        {
            return rep.InicializeToDo(UserID);
        }

        public Task InicializeUSers()
        {
           return rep.InicializeUSersAsync();
        }
    }
}
