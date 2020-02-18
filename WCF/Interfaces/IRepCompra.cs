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
    public interface IRepCompra
    {
        [OperationContract]
        List<RepCompra> GetResumenOperaciones(string idEmpresa, string id_moneda, string desde, string hasta);
        [OperationContract]
        List<RepCompra> GetDetalleOperaciones(string idEmpresa, string id_moneda, string id_tipo, string desde, string hasta);
        [OperationContract]
        List<RepCompra> GetProveedorOperaciones(string idEmpresa, string id_moneda, string id_proveedor, string desde, string hasta);
    }
}
