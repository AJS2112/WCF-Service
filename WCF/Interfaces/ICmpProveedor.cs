﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    [ServiceContract]
    public interface ICmpProveedor
    {
        [OperationContract]
        List<CmpProveedor> GetList(string idEmpresa);
        [OperationContract]
        CmpProveedor GetOne(string idEmpresa, string id);
        [OperationContract]
        string SetOne(CmpProveedor one);
    }
}
