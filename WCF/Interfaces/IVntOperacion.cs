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
    public interface IVntOperacion
    {
        [OperationContract]
        List<VntOperacion> GetDeudasCliente(string idCliente);
        [OperationContract]
        List<VntOperacion> GetList(string idEmpresa, string idTipo);
        [OperationContract]
        VntOperacion GetOne(string idEmpresa, string idTipo, string id);
        [OperationContract]
        string SetAbono(VntOperacion one, List<CajMovimiento> pago);
        [OperationContract]
        string SetOne(VntOperacion one, List<InvMovimiento> detail, List<CajMovimiento> pago);
        [OperationContract]
        string NullOne(VntOperacion one, List<InvMovimiento> detail);
    }
}
