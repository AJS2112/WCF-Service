using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IInvPrroductoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IInvProducto
    {
        [OperationContract]
        List<InvProducto> GetList(string idEmpresa);
        [OperationContract]
        List<InvProducto> GetListPV(string idEmpresa);
        [OperationContract]
        InvProducto GetOne(string idEmpresa, string id);
        [OperationContract]
        string SetOne(InvProducto one);
    }
}
