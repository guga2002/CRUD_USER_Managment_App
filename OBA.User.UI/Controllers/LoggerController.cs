using BOA.User.Source.ResponseAndRequest.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBA.User.Core.Interfaces;
using OBA.User.Core.Models;
using OBA.User.Core.Services;

namespace OBA.User.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminOnly")]
    public class LoggerController : ControllerBase
    {
        private readonly  ILoggerServices servic;
        public LoggerController( ILoggerServices ser)
        {
            servic = ser;
        }
        [HttpPost("ByItType")]
        public IActionResult GetLogsByItType(GetLogsByittyperequest req)
        {
            try
            {
                if (req == null) return BadRequest(" bad argument");
                var res = servic.GetLogsByItType(req);
                if (res == null) return NotFound(" no data exist");
                return Ok(res);
            }
            catch (Exception exp)
            {
                return StatusCode(200, exp.Message);
            }
        }
        [HttpPost("WithDateRange")]
        public IActionResult GetLogsByDateRange(GetLogsRequest req)
        {
            try
            {
                if (req == null) return BadRequest(" bad argument");
                var res = servic.GetLogsByDateRange(req);
                if (res == null) return NotFound(" no data exist");
                return Ok(res);
            }
            catch (Exception exp)
            {
                return StatusCode(200, exp.Message);
            }
        }
        [HttpGet("AllLogs")]
        public IActionResult GetAllLogs()
        {
            try
            {
                var res = servic.GetAllLogs();
                if (res == null)
                    return NotFound(" no logs exists");
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
