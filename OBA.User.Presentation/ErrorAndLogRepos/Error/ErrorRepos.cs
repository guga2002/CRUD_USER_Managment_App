using BOA.User.Source.HelperEnum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Core.Models;
using OBA.User.Infrastructure.Data.DbContexti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBA.User.Core.Models;
using BOA.User.Source.ResponseAndRequest.Request;

namespace OBA.User.Presentation.ErrorAndLogRepos.Error
{
    public class ErrorRepos:IerrorRepos
    {

        private readonly AppDbContext _db;

        public ErrorRepos(AppDbContext _db)
        {
                this._db = _db;
        }

        public void Action(string mesage, typeEnums enm)
        {
            _db.Errors.Add(new Core.Models.Error()
            {
                text = mesage,
                type = enm,
                time = DateTime.Now
            });
        }

        public List<OBA.User.Core.Models.Error> GetAllErrors()
        {
            return _db.Errors.ToList();
        }

        public List<OBA.User.Core.Models.Error> GetErrorsWithDateRange(GetErrorsWithDateRange req)
        {
            var lst = _db.Errors.Where(io => io.time >= req.start && io.time <= req.end).ToList();
            return lst;
        }

        public List<OBA.User.Core.Models.Error> GetErrorsByItType(GetErrorByItTypeRequest req)
        {
            var lst = _db.Errors.Where(io => io.type == req.errorType).ToList();
            return lst;
        }
    }
}
