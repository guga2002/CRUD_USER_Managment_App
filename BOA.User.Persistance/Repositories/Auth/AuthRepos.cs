using BOA.User.Source.ResponseAndRequest.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OBA.User.Core.Interfaces;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Core.Models;
using OBA.User.Infrastructure.Data.DbContexti;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BOA.User.Persistance.Repositories.Auth
{
    public  class AuthRepos: IauthRepos
    {
        private readonly UserManager<Useri> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IConfiguration config;
        private readonly AppDbContext _Database;
        private readonly IerrorRepos error;
        private readonly ILogRepos log;
        public AuthRepos(ILogRepos log,IerrorRepos ser,UserManager<Useri> _usr, IConfiguration con, AppDbContext database, RoleManager<IdentityRole> role)
        {
            _usermanager = _usr;
            config = con;
            _Database = database;
            _rolemanager = role;
            error = ser;
            this.log = log;
        }

        public async Task<bool> Register(RegisterRequest user)
        {
            var identifier = _Database.Users.Max(io => io.UserIdentifier)+1; ;
            Useri usra = new Useri()
            {
                Email = user.Email,
                UserName = user.Username,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PhoneNumber = user.Phone,
                action = DateTime.Now,
                UserIdentifier = identifier,
               
            };

            if (usra != null)
            {
                var res = await _usermanager.CreateAsync(usra, user.Password);

                if (res.Succeeded)
                {
                    // Check if the role exists, and create it if it doesn't
                    string role = user.Role.ToUpper();
                    if (role == "ADMIN" || role == "USER" || role == "MODERATOR" || role == "GUEST" || role == "MANAGER")
                    {
                        await Console.Out.WriteLineAsync("roli  validuria");

                        var roleExists = await _rolemanager.RoleExistsAsync(user.Role.ToUpper());

                        await Console.Out.WriteLineAsync(roleExists.ToString());

                        if (!roleExists)
                        {
                            var roleResult = await _rolemanager.CreateAsync(new IdentityRole(user.Role.ToUpper()));

                            if (!roleResult.Succeeded)
                            {

                                return false;
                            }
                        }

                        await _usermanager.AddToRoleAsync(usra, user.Role.ToUpper());

                        await Console.Out.WriteLineAsync("warmatebit daemata");
                        await _Database.SaveChangesAsync();
                        var time =  _Database.Users.Max(io => io.action);
                        var userid = await _Database.Users.Where(io => io.action == time).Select(io=>io.Id).FirstOrDefaultAsync();
                        if(userid!=null)
                        {
                            _Database.Profiles.Add(new UserProfile()
                            {
                                Firstname = user.Firstname,
                                Lastname = user.Lastname,
                                PersonalNumber = user.PersonalNumber,
                                UserID = userid,

                            }) ;
                            _Database.SaveChangesAsync();
                        }
                        return true;
                    }
                }
            }
            error.Action("Warumatebeli registracia", Source.HelperEnum.typeEnums.debbuging);
            return false;
        }


        public async Task<string> SignIn(SIgnInRequest sign)
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

        private async Task<string> GenerateJwtToken(Useri user, string Role)
        {
            if (user != null)
            {
                var claims = new[]
                {
              new Claim(ClaimTypes.NameIdentifier, user.Id),
              new Claim(ClaimTypes.Name, user.UserName),
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
    }
}
