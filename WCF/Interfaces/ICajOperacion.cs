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
    public interface ICajOperacion
    {
        [OperationContract]
        List<CajOperacion> GetList(string idEmpresa, string idTipo);
        [OperationContract]
        CajOperacion GetOne(string idEmpresa, string idTipo, string id);
        [OperationContract]
        string SetOne(CajOperacion one, List<CajMovimiento> detail);
        [OperationContract]
        string NullOne(CajOperacion one);
    }
}
