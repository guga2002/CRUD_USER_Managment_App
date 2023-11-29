using BOA.User.Source.HelperEnum;
using BOA.User.Source.ResponseAndRequest.Request;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Core.Models;
using OBA.User.Infrastructure.Data.DbContexti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Presentation.ErrorAndLogRepos.LOg
{
    public class LoggerRepos:ILogRepos
    {
        private readonly AppDbContext _db;

        public LoggerRepos(AppDbContext _db)
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

        public List<Log> GetAllLogs()
        {
            return _db.logs.ToList();
        }

        public List<Log> GetLogsByDateRange(GetLogsRequest req)
        {
            var lst = _db.logs.Where(io => io.time <= req.end && io.time >= req.start).ToList();
            return lst;
        }

        public List<Log> GetLogsByItType(GetLogsByittyperequest req)
        {
            return _db.logs.Where(io=>io.type==req.typeenm).ToList();
        }
    }
}
