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
    public interface IColMovimiento
    {
        [OperationContract]
        bool Delete(string idOperacion);
        [OperationContract]
        List<ColMovimiento> GetList(string idOperacion);
        [OperationContract]
        string SetOne(ColMovimiento one);
    }
}
