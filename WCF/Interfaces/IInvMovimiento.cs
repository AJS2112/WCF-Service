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
    public interface IInvMovimiento
    {
        [OperationContract]
        bool Delete(string idOperacion);
        [OperationContract]
        List<InvMovimiento> GetList(string idOperacion);
        [OperationContract]
        List<InvMovimiento> GetListByOrigen(string idOperacion);
        [OperationContract]
        string SetOne(InvMovimiento one);
    }
}
