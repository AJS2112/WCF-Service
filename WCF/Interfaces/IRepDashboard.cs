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
    public interface IRepDashboard
    {
        [OperationContract]
        List<RepDashboard> GetResumenCaja(string idEmpresa, string desde, string hasta);
        [OperationContract]
        List<RepDashboard> GetResumenGeneral(string idEmpresa, string desde, string hasta);
    }
}
