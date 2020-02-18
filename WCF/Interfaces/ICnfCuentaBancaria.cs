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
    public interface ICnfCuentaBancaria
    {
        [OperationContract]
        List<CnfCuentaBancaria> GetList(string idEmpresa);
        [OperationContract]
        CnfCuentaBancaria GetOne(string idEmpresa, string id);
        [OperationContract]
        string SetOne(CnfCuentaBancaria one);
    }
}
