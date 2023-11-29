using BOA.User.Source.HelperEnum;
using BOA.User.Source.ResponseAndRequest.Request;
using OBA.User.Core.Interfaces;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Core.Models;

namespace OBA.User.Core.Services
{
    public  class LoggerServices: ILoggerServices
    {
        private readonly ILogRepos rep;

        public LoggerServices(ILogRepos rep)
        {
            this.rep = rep;
                
        }

        public List<Log> GetAllLogs()
        {
            return rep.GetAllLogs();
        }

        public List<Log> GetLogsByDateRange(GetLogsRequest req)
        {
            return rep.GetLogsByDateRange(req);
        }

        public List<Log> GetLogsByItType(GetLogsByittyperequest req)
        {
            return rep.GetLogsByItType(req);
        }
    }
}
