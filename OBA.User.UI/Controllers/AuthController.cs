using BOA.User.Source.ResponseAndRequest.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBA.User.Core.Interfaces;

namespace OBA.User.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService ser)
        {
            service = ser;  
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SIgnInRequest sign)//shesvlas ar chirdeba avtorizacia
        {
            try
            {
                var res = await service.SignIn(sign);
                if (res == null)
                    return NotFound("signinfailed");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(100, "somethings goes wrong");
                throw;
            }
           
        }
    }
}
