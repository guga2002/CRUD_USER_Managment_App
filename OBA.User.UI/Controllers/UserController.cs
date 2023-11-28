using BOA.User.Source.ResponseAndRequest.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OBA.User.Core.Interfaces;
using System.Security.Claims;

namespace OBA.User.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices ser;
        public UserController(IUserServices se)
        {
            ser = se;
        }

        [HttpPost("Register")]
       public  async Task<IActionResult> Register(RegisterRequest user)// registracias ar chirdeba avtorizacia
        {
            try
            {

                if (user == null)
                {
                    return NotFound(" no  data exist");
                }
                var res = await ser.Register(user);
                if (res == false)
                {
                    return BadRequest("warumatebeli registracia");
                }
                return Ok("warmatebuli registracia");

            }
            catch (Exception exp)
            {

                return StatusCode(100, exp.Message);
            }
        }
        [HttpPost("View")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UserOnly")]
        public IActionResult ViewProfile(ViewProfileRequest req)
        {
            try
            {

                if (req == null)
                {
                    var userid = User.FindFirst(ClaimTypes.GivenName)?.Value;

                    var profile = new ViewProfileRequest() { PersonalNumber = userid };
                    // is shemtxveva roca naxulobs sakutar profils;
                    var res = ser.ViewProfile(profile);
                    if (res == null) return NotFound(" no  profile exist for you");
                    return Ok(res);
                }
                var rek = ser.ViewProfile(req);
                if (rek == null) return BadRequest(" no profile exist for this user");
                return Ok(rek);
            }
            catch (Exception exp)
            {
                return StatusCode(100, exp.Message);
            }
        }

        [HttpPatch("Edit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UserOnly")]
        public IActionResult  EditProfile(EditRequest req)
        {
            try
            {
                if (req == null)
                {
                    var userid = User.FindFirst(ClaimTypes.GivenName)?.Value;

                    var profile = req;
                    profile.PersonalNumber = userid;
                    // is shemtxveva roca naxulobs sakutar profils;
                    var res = ser.EditProfile(profile);
                    if (res == null) return NotFound(" no  profile exist for you");
                    return Ok("warmatebit daredsqtirda");
                }
                var rek = ser.EditProfile(req);
                if (rek == null) return BadRequest(" no profile exist for this user");
                return Ok("warmatebit daredaqtirda");
            }
            catch (Exception exp)
            {
                return StatusCode(100, exp.Message);
            }
        }
        [HttpPost("SoftDelete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UserOnly")]
        public IActionResult SoftDelete(SoftDeleteReqest req)
        {
            try
            {
                if(req==null)
                {
                    return BadRequest("Please inicialise  the Req");
                }
                return Ok(ser.SoftDelete(req));
            }
            catch (Exception exp)
            {
                return StatusCode(100, exp.Message);
            }

        }
        [HttpDelete("Delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminOnly")]//only admin can  delete user
        public IActionResult PermanentlyDelete(PermanentlyDeleteRequest req)
        {
            try
            {
                if (req == null)
                {
                    return BadRequest("Please inicialise  the Req");
                }
                return Ok(ser.PermanentlyDelete(req));
            }
            catch (Exception exp)
            {
                return StatusCode(100, exp.Message);
            }
        }
    }
}
