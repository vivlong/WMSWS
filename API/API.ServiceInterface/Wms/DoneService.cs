﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WmsWS.ServiceModel;
using WmsWS.ServiceModel.Wms;

namespace WmsWS.ServiceInterface.Wms
{
    public class DoneService
    {
        public void initial(Auth auth, Update_Done request, Update_Done_Logic eventdoneLogic, CommonResponse ecr, string[] token, string uri)
        {
            if (auth.AuthResult(token, uri))
            {
                if (eventdoneLogic.UpdateDone(request) > 0)
                {
                    ecr.meta.code = 200;
                    ecr.meta.message = "OK";
                }
                else
                {
                    ecr.meta.code = 612;
                    ecr.meta.message = "The specified resource does not exist";
                }
            }
            else
            {
                ecr.meta.code = 401;
                ecr.meta.message = "Unauthorized";
            }
        }
    }
}
