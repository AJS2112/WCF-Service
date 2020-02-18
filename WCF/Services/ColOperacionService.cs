using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class ColOperacionService : IColOperacion
    {
        ColOperacion srv = new ColOperacion();

        public bool ActualizarCola()
        {
            return ColNotificacion.hayNotificacion;
        }
        public List<ColOperacion> GetList(string idEmpresa, string idTipo, int idStatus)
        {
            List<ColOperacion> _list = srv.GetList(idEmpresa, idTipo, idStatus);
            ColNotificacion.hayNotificacion = false;
            return _list;
        }

        public ColOperacion GetOne(string idEmpresa, string idTipo, string id)
        {
            ColOperacion _one = srv.GetOne(idEmpresa, idTipo, id);
            return _one;
        }
        
        public string SetOne(ColOperacion one, List<ColMovimiento> detail)
        {
            string _id = srv.SetOne(one, detail);
            ColNotificacion.hayNotificacion = true;
            return _id;
        }
        public string UpdateOne(ColOperacion one, int idStatus)
        {
            string _id = srv.UpdateOne(one, idStatus);
            ColNotificacion.hayNotificacion = true;
            return _id;
        }
    }
}
