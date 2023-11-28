using BOA.User.Source.HelperEnum;
using OBA.User.Core.Interfaces.Repos;
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
    }
}
