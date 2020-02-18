using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class CajOperacionService : ICajOperacion
    {
        CajOperacion srv = new CajOperacion();

        public List<CajOperacion> GetList(string idEmpresa, string idTipo)
        {
            List<CajOperacion> _list = srv.GetList(idEmpresa, idTipo);
            return _list;
        }

        public CajOperacion GetOne(string idEmpresa, string idTipo, string id)
        {
            CajOperacion _one = srv.GetOne(idEmpresa, idTipo, id);
            return _one;
        }

        public string NullOne(CajOperacion one)
        {
            string _id = srv.NullOne(one);
            return _id;
        }

        public string SetOne(CajOperacion one, List<CajMovimiento> detail)
        {
            string _id = srv.SetOne(one, detail);
            return _id;
        }
    }
}
