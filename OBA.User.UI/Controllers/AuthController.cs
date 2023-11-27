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

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest user)
        {
            var res = await service.Register(user);
            if (res == false) return BadRequest(" no success");
            return Ok(res);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SIgnInRequest sign)
        {
            var res=await service.SignIn(sign);
            if (res == null)
                return NotFound("signinfailed");
            return Ok(res); 
        }
    }
}
