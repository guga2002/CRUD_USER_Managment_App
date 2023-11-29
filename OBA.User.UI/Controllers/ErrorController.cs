using BOA.User.Source.ResponseAndRequest.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OBA.User.Core.Interfaces;

namespace OBA.User.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminOnly")]
    public class ErrorController : ControllerBase// mxolod admins aqvs am kontrolerze wvdoma
    {
        private readonly IErrorservice servic;

        public ErrorController(IErrorservice ser)
        {
            servic = ser;
        }
        [HttpGet("AllErrors")]
       public IActionResult GetAllErrors()
        {
            try
            {
                var res = servic.GetAllErrors();
                if(res==null)
                {
                    return NotFound("No data found");
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                return StatusCode(200, exp.Message);
            }
        }
        [HttpPost("WithDateRange")]
        public IActionResult GetErrorsWithDateRange(GetErrorsWithDateRange req)
        {
            try
            {
                if (req == null) return BadRequest("Argument is null");
                var res = servic.GetErrorsWithDateRange(req);
                if (res == null)
                {
                    return NotFound("No data found");
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                return StatusCode(200, exp.Message);
            }
        }
        [HttpPost("ByItType")]
        public IActionResult GetErrorsByItType(GetErrorByItTypeRequest req)
        {
            try
            {
                if (req == null) return BadRequest("Argument is null");
                var res = servic.GetErrorsByItType(req);
                if (res == null)
                {
                    return NotFound("No data found");
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                return StatusCode(200, exp.Message);
            }
        }
    }
}
