using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class ColMovimientoService : IColMovimiento
    {
        ColMovimiento srv = new ColMovimiento();
        public bool Delete(string idOperacion)
        {
            bool _res = srv.Delete(idOperacion);
            return _res;
        }

        public List<ColMovimiento> GetList(string idOperacion)
        {
            List<ColMovimiento> _list = srv.GetList(idOperacion);
            return _list;
        }

        public string SetOne(ColMovimiento one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
