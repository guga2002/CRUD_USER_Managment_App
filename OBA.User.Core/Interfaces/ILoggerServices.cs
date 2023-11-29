using BOA.User.Source.HelperEnum;
using BOA.User.Source.ResponseAndRequest.Request;
using OBA.User.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Interfaces
{
    public interface ILoggerServices
    {
        List<Log> GetLogsByItType(GetLogsByittyperequest req);
        List<Log> GetLogsByDateRange(GetLogsRequest req);
        List<Log> GetAllLogs();


    }
}
