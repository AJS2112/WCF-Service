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
    public interface IRepInventario
    {
        [OperationContract]
        List<RepInventario> GetResumenMovimientos(string idEmpresa, string id_categoria, string desde, string hasta);
        [OperationContract]
        List<RepInventario> GetDetalleMovimientos(string idEmpresa, string id_producto, string desde, string hasta);

    }
}
