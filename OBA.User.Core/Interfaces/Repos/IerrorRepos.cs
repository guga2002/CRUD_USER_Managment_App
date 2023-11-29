﻿using BOA.User.Source.HelperEnum;
using BOA.User.Source.ResponseAndRequest.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBA.User.Core.Interfaces.Repos
{
    public interface IerrorRepos
    {
        void Action(string mesage, typeEnums enm);
        List<OBA.User.Core.Models.Error> GetAllErrors();
        List<OBA.User.Core.Models.Error> GetErrorsWithDateRange(GetErrorsWithDateRange req);
        List<OBA.User.Core.Models.Error> GetErrorsByItType(GetErrorByItTypeRequest req);
    }
}
