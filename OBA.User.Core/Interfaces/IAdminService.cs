using BOA.User.Source.ResponseAndRequest.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Interfaces
{
    public interface IAdminService
    {
        Task InicializeUSers();
        bool InicializeToDo(inicializetodoRequest UserID);
        bool InicializeAlbum(AlbumInicializeRequest req);
        bool InicializePictures(InicializePicturesRequest req);
        bool InicializePosts(InicializePostRequest req);
        bool InicializeCOmentars(InicializeCOmentarsRequest req);
    }
}
