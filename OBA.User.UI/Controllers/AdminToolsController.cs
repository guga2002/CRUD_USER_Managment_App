using BOA.User.Source.ResponseAndRequest.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBA.User.Core.Interfaces;

namespace OBA.User.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminToolsController : ControllerBase
    {
        private readonly IAdminService ser;

        public AdminToolsController(IAdminService ser)
        {
            this.ser = ser;  
        }


        [HttpPost("Inicialize")]
        public Task  inicialize()
        {
           return  ser.InicializeUSers();
        }

        [HttpPost("InicializeToDo")]
        public bool InicializeToDo(inicializetodoRequest UserID)
        {
            return ser.InicializeToDo(UserID);
        }

        [HttpPost("InicializeAlbum")]
        public bool InicializeAlbum(AlbumInicializeRequest req)
        {
            return ser.InicializeAlbum(req);
        }
        [HttpPost("InicializePhotos")]
        public bool InicializePictures(InicializePicturesRequest req)
        {
            return ser.InicializePictures(req);
        }

        [HttpPost("InicializePosts")]
        public bool InicializePosts(InicializePostRequest req)
        {
            return ser.InicializePosts(req);
        }

        [HttpPost("InicializeCOments")]
        public bool InicializeCOmentars(InicializeCOmentarsRequest req)
        {
            return ser.InicializeCOmentars(req);
        }
    }
}
