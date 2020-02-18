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
    public interface IColOperacion
    {
        [OperationContract]
        bool ActualizarCola();
        [OperationContract]
        List<ColOperacion> GetList(string idEmpresa, string idTipo, int idStatus);
        [OperationContract]
        ColOperacion GetOne(string idEmpresa, string idTipo, string id);
        [OperationContract]
        string SetOne(ColOperacion one, List<ColMovimiento> detail);
        [OperationContract]
        string UpdateOne(ColOperacion one, int idStatus);
    }
}
