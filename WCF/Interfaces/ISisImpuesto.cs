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
    public interface ISisImpuesto
    {
        [OperationContract]
        List<SisImpuesto> GetList(string id);
    }
}
