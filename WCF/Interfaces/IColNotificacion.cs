using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    [ServiceContract (CallbackContract =typeof(IColNotificacionCallback))]
    public interface IColNotificacion
    {
        [OperationContract]
        void AskNotificacion();
    }

    public interface IColNotificacionCallback
    {
        [OperationContract]
        void DoNotificacion(bool actualizacionesPendientes);
    }
}
