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
    public interface IVntCliente
    {
        [OperationContract]
        List<VntCliente> GetList(string idEmpresa);
        [OperationContract]
        VntCliente GetOne(string idEmpresa, string id);
        [OperationContract]
        string SetOne(VntCliente one);
    }
}
