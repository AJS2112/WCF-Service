using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class CajMovimientoService : ICajMovimiento
    {
        CajMovimiento srv = new CajMovimiento();
        public bool Delete(string idOperacion)
        {
            bool _res = srv.Delete(idOperacion);
            return _res;
        }

        public List<CajMovimiento> GetList(string idOperacion)
        {
            List<CajMovimiento> _list = srv.GetList(idOperacion);
            return _list;
        }

        public string SetOne(CajMovimiento one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
