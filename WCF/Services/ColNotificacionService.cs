using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Timers;
using WCF.Entities;

namespace WCF
{
    [ServiceBehavior(ConcurrencyMode =ConcurrencyMode.Reentrant)]
    public class ColNotificacionService : IColNotificacion
    {
        public void AskNotificacion()
        {
            
            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(1000);
                if (ColNotificacion.hayNotificacion)
                {
                    try
                    {
                        OperationContext.Current.GetCallbackChannel<IColNotificacionCallback>().DoNotificacion(ColNotificacion.hayNotificacion);
                        ColNotificacion.hayNotificacion = false;
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
            

            /*
            System.Timers.Timer timer = new System.Timers.Timer() { Interval = 1000 };
            int counter = 0; // counter has just this mission
            timer.Elapsed += (s, e) => OperationContext.Current.GetCallbackChannel<IColNotificacionCallback>().DoNotificacion(counter++);
            timer.Start();
            */
            //bool hayActualizaciones = true;
            //OperationContext.Current.GetCallbackChannel<IColNotificacionCallback>().DoNotificacion(hayActualizaciones);
        }
    }
}
