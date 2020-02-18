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
    public interface IRepCaja
    {
        [OperationContract]
        List<RepCaja> GetCuentasDetalle(string idEmpresa, string id_moneda, string id_cuenta, string desde, string hasta);
        [OperationContract]
        List<RepCaja> GetCuentasResumen(string idEmpresa, string id_moneda, string desde, string hasta);
        [OperationContract]
        List<RepCaja> GetInstrumentosDetalle(string idEmpresa, string id_moneda, string id_instrumento, string desde, string hasta);
        [OperationContract]
        List<RepCaja> GetInstrumentosResumen(string idEmpresa, string id_moneda, string desde, string hasta);
    }
}
