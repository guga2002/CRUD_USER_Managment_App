using BOA.User.Source.ResponseAndRequest.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Core.Models;
using OBA.User.Infrastructure.Data.DbContexti;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BOA.User.Persistance.Repositories.Auth
{
    public  class AuthRepos: IauthRepos
    {
        private readonly UserManager<Useri> _usermanager;
        private readonly RoleManager<Identityroleb> _rolemanager;
        private readonly IConfiguration config;
        private readonly AppDbContext db;
        private readonly IerrorRepos error;
        private readonly ILogRepos log;
        public AuthRepos(AppDbContext db,ILogRepos log,IerrorRepos ser,UserManager<Useri> _usr, IConfiguration con, RoleManager<Identityroleb> role)
        {
            _usermanager = _usr;
            this.db = db;
            config = con;
            _rolemanager = role;
            error = ser;
            this.log = log;
        }

        #region SignIN

        public async Task<string> SignIn(SIgnInRequest sign)
        {
            try
            {

                var res = await _usermanager.FindByNameAsync(sign.Username);
                if (res == null) return null;

                var checkedpass = await _usermanager.CheckPasswordAsync(res, sign.Password);
                if (checkedpass)
                {
                    var rolik = await _usermanager.GetRolesAsync(res);
                    if (rolik.FirstOrDefault() != null)
                    {
                        await Console.Out.WriteLineAsync(rolik.First());
                        var re = await GenerateJwtToken(res, rolik.First());
                        if (re == null) return null;
                        return re;
                    }
                    error.Action("role is null there", Source.HelperEnum.typeEnums.Easy);
                    await Console.Out.WriteLineAsync("role is null there");
                }

                return null;

            }
            catch (Exception exp)
            {

                throw exp;
            }

        }
        #endregion

        #region GenerateJwtToken
        private async Task<string> GenerateJwtToken(Useri user, string Role)
        {
            try
            {


                if (user != null)
                {
                    var profile = db.Profiles.Where(io => io.userProfileID == user.Id).FirstOrDefault();
                    var claims = new[]
                    {
              new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
              new Claim(ClaimTypes.Name, user.UserName),
              new Claim(ClaimTypes.GivenName,profile.PersonalNumber),
              new Claim(ClaimTypes.Role,Role),

            };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt:key").Value));

                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: config.GetSection("Jwt:Issuer").Value,
                        audience: config.GetSection("Jwt:Audience").Value,
                        claims: claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: credentials
                    );
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                return null;
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }
        #endregion
    }
}
