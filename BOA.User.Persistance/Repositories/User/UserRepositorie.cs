using BOA.User.Source.ResponseAndRequest.Request;
using BOA.User.Source.ResponseAndRequest.Response;
using Microsoft.AspNetCore.Identity;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Core.Models;
using OBA.User.Infrastructure.Data.DbContexti;
using System.Transactions;

namespace BOA.User.Persistance.Repositories.User
{
    public  class UserRepositorie:IuserRepos
    {

        private readonly AppDbContext _DB;
        private readonly UserManager<Useri> _usermanager;
        private readonly RoleManager<Identityroleb> _rolemanager;
        private readonly ILogRepos log;
        private readonly IerrorRepos error;

        public UserRepositorie(UserManager<Useri> _usr, AppDbContext database, RoleManager<Identityroleb> role, ILogRepos rep, IerrorRepos er)
        {
            _usermanager = _usr;
            _rolemanager = role;
            _DB = database;
            log = rep;
            error = er;
        }

        #region RegisterUser
        public async Task<bool> Register(RegisterRequest user)
        {
            using (var transact = _DB.Database.BeginTransaction())
            {
                try
                {
                    if(_DB.Profiles.Any(io => io.PersonalNumber == user.PersonalNumber))
                    {
                        error.Action("Msgavsi user ukve arsebobs bazashi", Source.HelperEnum.typeEnums.medium);
                        return false;
                    }

                    int addresid = 0;
                    int companieId = 0;
                    if (_DB.Addresses.Any(io => io.city == user.city && io.street == user.street && io.zipcode == user.zipcode))
                    {
                        addresid = _DB.Addresses.Max(io => io.AddressID);
                    }
                    else
                    {
                        _DB.Addresses.Add(new Address()
                        {
                            city = user.city,
                            street = user.city,
                            zipcode = user.zipcode,
                            suite = user.suite
                        });
                        _DB.SaveChanges();
                        addresid = _DB.Addresses.Max(io => io.AddressID);
                    }

                    if (_DB.Companies.Any(io => io.Name == user.NameofCompanie && io.CatchPhrase == user.CatchPhrase))
                    {
                        companieId = _DB.Companies.Max(io => io.CompanieID);
                    }
                    else
                    {
                        _DB.Companies.Add(new Company()
                        {
                            BS = user.BS,
                            CatchPhrase = user.CatchPhrase,
                            Name = user.NameofCompanie
                        });
                        _DB.SaveChanges();
                        companieId = _DB.Companies.Max(io => io.CompanieID);
                    }

                    int UserprofileID = 0;

                        _DB.Add(new UserProfile()
                        {
                            Firstname = user.Firstname,
                            Lastname = user.Lastname,
                            PersonalNumber = user.PersonalNumber,
                            AddressID = addresid,
                            CompanieID = companieId,
                        });
                        _DB.SaveChanges();
                        UserprofileID = _DB.Profiles.Max(us => us.userProfileID);
                   

                    Useri usra = new Useri()
                    {
                        Email = user.Email,
                        UserName = user.Username,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PhoneNumber = user.Phone,
                        action = DateTime.Now,
                        ProfileID = UserprofileID,
                        IsActive = true,
                    };

                    if (usra != null)
                    {
                        var res = await _usermanager.CreateAsync(usra, user.Password);

                        if (res.Succeeded)
                        {
                           
                            string role = user.Role.ToUpper();
                            if (role == "ADMIN" || role == "USER" || role == "MODERATOR" || role == "GUEST" || role == "MANAGER")
                            {
                              

                                var roleExists = await _rolemanager.RoleExistsAsync(user.Role.ToUpper());

                                await Console.Out.WriteLineAsync(roleExists.ToString());
                                if (!roleExists)
                                {
                                    var roleResult = await _rolemanager.CreateAsync(new Identityroleb(role.ToUpper()));

                                    if (!roleResult.Succeeded)
                                    {
                                       transact.Rollback();
                                        return false;
                                    }
                                }

                                await _usermanager.AddToRoleAsync(usra, user.Role.ToUpper());

                                await Console.Out.WriteLineAsync("warmatebit daemata");
                                await _DB.SaveChangesAsync();
                               transact.Commit();
                                log.Action("Warmatebuli registracia bazashi ", Source.HelperEnum.typeEnums.info);
                                return true;
                            }
                        }
                    }
                    error.Action("Warumatebeli registracia", Source.HelperEnum.typeEnums.debbuging);
                    transact.Rollback();
                    return false;

                }
                catch (Exception exp)
                {
                    transact.Rollback();
                    error.Action(exp.Message, Source.HelperEnum.typeEnums.Hard);
                    throw exp;
                }
            }
        }
        #endregion

        #region ViewProfile
        public UserViewResponse ViewProfile(ViewProfileRequest req)
        {
            try
            {


                if (_DB.Profiles.Any(io => io.PersonalNumber == req.PersonalNumber && io.address != null && io.company != null))
                {
                    var userid = _DB.Profiles.Where(io => io.PersonalNumber == req.PersonalNumber).Select(io => io.userProfileID).FirstOrDefault();
                    var user = _DB.Users.Where(io => io.ProfileID == userid).FirstOrDefault();

                    if (user != null)
                    {
                        if (user.IsActive == false)
                        {
                            error.Action("User ar aris aqtiuri amitomac ver Vnaxavt profils", Source.HelperEnum.typeEnums.debbuging);
                            return null;
                        }
                    }
                    var resp = _DB.Profiles.Where(io => io.PersonalNumber == req.PersonalNumber).Select(io =>
                    new UserViewResponse()
                    {
                        Firstname = io.Firstname,
                        Lastname = io.Lastname,
                        BS = io.company.BS,
                        CatchPhrase = io.company.CatchPhrase,
                        city = io.address.city,
                        PersonalNumber = io.PersonalNumber,
                        street = io.address.street,
                        suite = io.address.suite,
                        zipcode = io.address.zipcode,
                        Name = io.company.Name
                    }).FirstOrDefault();
                    log.Action($"Successfully take user data: {resp.Name + ' ' + resp.PersonalNumber}", Source.HelperEnum.typeEnums.info);
                    return resp;
                }
                else
                {
                    error.Action("Useri ar arsebobs bazashi msgavs monacemebze", Source.HelperEnum.typeEnums.Easy);
                    return null;
                }
            }
            catch (Exception exp)
            {
                error.Action(exp.Message, Source.HelperEnum.typeEnums.medium);
                throw exp;
            }
        }

        #endregion

        #region EditPRofile
        public bool EditProfile(EditRequest req)
        {
            using (var transac = _DB.Database.BeginTransaction())
            {
                try
                {
                    if (_DB.Profiles.Any(io => io.PersonalNumber == req.PersonalNumber))
                    {
                        var userid = _DB.Profiles.Where(io => io.PersonalNumber == req.PersonalNumber).Select(io => io.userProfileID).FirstOrDefault();
                        var user = _DB.Users.Where(io => io.ProfileID == userid).FirstOrDefault();
                        if (user != null)
                        {
                            if (user.IsActive == false)
                            {
                                error.Action("User ar aris aqtiuri amitomac ver davaredaqtirebt", Source.HelperEnum.typeEnums.debbuging);
                                return false;
                            }
                        }

                        var userprofile = _DB.Profiles.Where(io => io.PersonalNumber == req.PersonalNumber).FirstOrDefault();
                        if (userprofile != null)
                        {
                            userprofile.Firstname = req.Firstname;
                            userprofile.Lastname = req.Lastname;
                            userprofile.PersonalNumber = req.PersonalNumber;
                            userprofile.address.city = req.city;
                            userprofile.address.street = req.street;
                            userprofile.address.suite = req.suite;
                            userprofile.address.zipcode = req.zipcode;
                            userprofile.company.CatchPhrase = req.CatchPhrase;
                            userprofile.company.BS = req.BS;
                            userprofile.company.Name = req.NameOfcompany;

                            _DB.SaveChanges();
                            transac.Commit();
                            log.Action("Warmatebit daredaqtirda useri",Source.HelperEnum.typeEnums.Easy);
                            return true;
                        }
                        transac.Rollback();
                        return false;

                    }
                    else
                    {
                        transac.Rollback();
                        return false;
                    }
                }
                catch (Exception exp)
                {
                    transac.Rollback();
                    error.Action(exp.Message, Source.HelperEnum.typeEnums.debbuging);
                    throw exp;
                }
            }

        }

        #endregion

        #region SoftDelete
        public bool SoftDelete(SoftDeleteReqest req)
        {
            try
            {
                var ind = _DB.Profiles.Where(io => io.PersonalNumber == req.PersonalNumber).Select(io => io.userProfileID).FirstOrDefault();
                if (ind != 0)
                {
                    var usr = _DB.Users.Where(io => io.ProfileID == ind).FirstOrDefault();
                    if (usr != null)
                    {
                        usr.IsActive = false;
                        _DB.SaveChanges();
                        log.Action($"User{usr.Id} succesfully soft deleted", Source.HelperEnum.typeEnums.medium);
                        return true;
                    }
                }
                error.Action($"No USer found in this index:{ind} ", Source.HelperEnum.typeEnums.Hard);
                return false;
            }
            catch (Exception exp)
            {
                error.Action(exp.Message, Source.HelperEnum.typeEnums.Hard);
                throw exp;
            }
        }
        #endregion

        #region PermanentlyDelete
        public bool PermanentlyDelete(PermanentlyDeleteRequest req)
        {
            try
            {
                var ind = _DB.Profiles.Where(io => io.PersonalNumber == req.PersonalNumber).Select(io => io.userProfileID).FirstOrDefault();
                if (ind != 0)
                {
                    var usr = _DB.Users.Where(io => io.ProfileID == ind).FirstOrDefault();
                    if (usr != null)
                    {
                        _DB.Remove(usr);
                        _DB.SaveChanges();
                        log.Action($"Successfully permanently delete  user {usr.Id} ", Source.HelperEnum.typeEnums.Easy);
                        return true;
                    }
                }
                error.Action(" no user Exist", Source.HelperEnum.typeEnums.medium);
                return false;

            }
            catch (Exception exp)
            {
                error.Action(exp.Message, Source.HelperEnum.typeEnums.Hard);

                throw exp;
            }
        }
        #endregion
    }
}
