using BOA.User.Source.HelperEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Interfaces.Repos
{
    public interface ILogRepos
    {
        void Action(string mesage, typeEnums enm);
    }
}
