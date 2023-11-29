using BOA.User.Source.ResponseAndRequest.Request;
using BOA.User.Source.ResponseAndRequest.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBA.User.Core.Interfaces;
using System.Security.Claims;

namespace OBA.User.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UserOnly")]
    public class AuthorizedUserController : ControllerBase
    {
        private readonly IregUserServices serv;

        public AuthorizedUserController( IregUserServices ser)
        {
            serv = ser;
        }

        [HttpPost("Posts")]
        public IActionResult GetPosts()//getting post  for  current signed in users
        {
            try
            {
                var ID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);// avtorizaciisas shevinaxe piradi nomeri
                if (ID < 1) return BadRequest(" somethings unusual happen");
                GetPostsRequest req = new GetPostsRequest() { UserID = ID };
                var res = serv.GetPosts(req);
                if (res == null) return NotFound(" no posts found");
                return Ok(res);
            }
            catch (Exception)
            {

                return StatusCode(100, "somethings unusuall");
            }
        }
        [HttpPost("ToDo")]
       public IActionResult GetToDo()
        {
            try
            {
                var ID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);// avtorizaciisas shevinaxe UserID
                if (ID < 1) return BadRequest("somethings unusual happen");
                ToDoRequest req = new ToDoRequest() { UserID = ID };
                Console.WriteLine(req.UserID);
                var res = serv.GetToDo(req);
                if (res == null) return NotFound(" no ToDo found");
                return Ok(res);
            }
            catch (Exception)
            {

                return StatusCode(100, "somethings unusuall");
            }
        }
        [HttpPost("Albums")]
        public IActionResult GetAlbums()
        {
            try
            {
                var ID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);// avtorizaciisas shevinaxe UserID
                if (ID < 1) return BadRequest("somethings unusual happen");
                GetAlbumRequest req = new GetAlbumRequest() { UserID = ID };
                var res = serv.GetAlbums(req);
                if (res == null) return NotFound(" no Album found, for you");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(100, "somethings unusuall");
            }
        }
    }
}
