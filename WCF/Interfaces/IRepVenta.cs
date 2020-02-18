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
    public interface IRepVenta
    {
        [OperationContract]
        List<RepVenta> GetResumenOperaciones(string idEmpresa, string id_moneda, string desde, string hasta);
        [OperationContract]
        List<RepVenta> GetDetalleOperaciones(string idEmpresa, string id_moneda, string id_tipo, string desde, string hasta);
        [OperationContract]
        List<RepVenta> GetClienteOperaciones(string idEmpresa, string id_moneda, string id_cliente, string desde, string hasta);
        [OperationContract]
        List<RepVenta> GetClienteDeudasResumen(string idEmpresa, string id_moneda);
        [OperationContract]
        List<RepVenta> GetClienteDeudasDetalle(string idEmpresa, string id_moneda, string id_cliente);
        [OperationContract]
        List<RepVenta> GetClientePagosRecibidos(string idEmpresa, string id_cliente, string desde, string hasta);
    }
}
