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
    public interface ISisListas
    {
        [OperationContract]
        List<SisListas> GetList(string id);
        [OperationContract]
        List<SisListas> GetListByCampo(string campo);
        [OperationContract]
        SisListas GetOne(string idEmpresa, string id);
        [OperationContract]
        string SetOne(SisListas one);
    }
}
