using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    [ServiceContract]
    public interface IInvCategoria
    {
        [OperationContract]
        List<InvCategoria> GetList(string idEmpresa);
        [OperationContract]
        InvCategoria GetOne(string idEmpresa, string id);
        [OperationContract]
        string SetOne(InvCategoria one);
    }
}
