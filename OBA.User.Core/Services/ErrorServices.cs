
using BOA.User.Source.ResponseAndRequest.Request;
using OBA.User.Core.Interfaces;
using OBA.User.Core.Interfaces.Repos;
using OBA.User.Core.Models;

namespace OBA.User.Core.Services
{
    public  class ErrorServices: IErrorservice
    {
        private readonly IerrorRepos rep;

        public ErrorServices(IerrorRepos rep)
        {
                this.rep=rep;
        }

        public List<Error> GetAllErrors()
        {
            return rep.GetAllErrors();
        }

        public List<Error> GetErrorsByItType(GetErrorByItTypeRequest req)
        {
            return rep.GetErrorsByItType(req);
        }

        public List<Error> GetErrorsWithDateRange(GetErrorsWithDateRange req)
        {
            return rep.GetErrorsWithDateRange(req);
        }
    }
}
