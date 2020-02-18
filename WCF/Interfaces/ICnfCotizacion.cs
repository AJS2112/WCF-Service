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
    public interface ICnfCotizacion
    {
        [OperationContract]
        List<CnfCotizacionDetalle> GetLast(string idEmpresa);
        [OperationContract]
        List<CnfCotizacion> GetList(string idEmpresa);
        [OperationContract]
        CnfCotizacion GetOne(string idEmpresa, string id);
        [OperationContract]
        List<CnfCotizacionDetalle> GetListDetail(string idCotizacion);
        [OperationContract]
        string SetOne(CnfCotizacion one, List<CnfCotizacionDetalle> detail);
    }
}
