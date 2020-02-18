using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class InvMovimientoService : IInvMovimiento
    {
        InvMovimiento srv = new InvMovimiento();
        public bool Delete(string idOperacion)
        {
            bool _res = srv.Delete(idOperacion);
            return _res;
        }

        public List<InvMovimiento> GetList(string idOperacion)
        {
            List<InvMovimiento> _list = srv.GetList(idOperacion);
            return _list;
        }

        public List<InvMovimiento> GetListByOrigen(string idOperacion)
        {
            List<InvMovimiento> _list = srv.GetListByOrigen(idOperacion);
            return _list;
        }

        public string SetOne(InvMovimiento one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
