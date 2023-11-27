using BOA.User.Source.HelperEnum;
using OBA.User.Core.Interfaces;
using OBA.User.Core.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Services
{
    public  class ErrorServices: IErrorservice
    {
        private readonly IerrorRepos rep;

        public ErrorServices(IerrorRepos rep)
        {
                this.rep=rep;
        }

        public void Action(string mesage, typeEnums enm)
        {
            rep.Action(mesage, enm);
        }
    }
}
