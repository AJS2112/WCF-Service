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
    public interface ICmpOperacion
    {
        [OperationContract]
        List<CmpOperacion> GetList(string idEmpresa, string idTipo);
        [OperationContract]
        CmpOperacion GetOne(string idEmpresa, string idTipo, string id);
        [OperationContract]
        string SetOne(CmpOperacion one, List<InvMovimiento> detail);
        [OperationContract]
        string NullOne(CmpOperacion one, List<InvMovimiento> detail);
    }
}
