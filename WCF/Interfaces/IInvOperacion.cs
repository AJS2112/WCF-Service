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
    public interface IInvOperacion
    {
        [OperationContract]
        List<InvOperacion> GetList(string idEmpresa, string idTipo);
        [OperationContract]
        InvOperacion GetOne(string idEmpresa, string idTipo, string id);
        [OperationContract]
        string SetOne(InvOperacion one, List<InvMovimiento> detail);
        [OperationContract]
        string NullOne(InvOperacion one, List<InvMovimiento> detail);
    }
}
