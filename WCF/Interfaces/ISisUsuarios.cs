using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISisUsuariosService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISisUsuarios
    {
        [OperationContract]
        List<SisUsuarios> GetList(string idEmpresa);
        [OperationContract]
        SisUsuarios Login(string logname, string pass);
    }
}
