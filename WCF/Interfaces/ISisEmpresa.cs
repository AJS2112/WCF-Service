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
    public interface ISisEmpresa
    {
        [OperationContract]
        SisEmpresa GetOne(string id);

        [OperationContract]
        string SetOne(SisEmpresa one);
    }
}
