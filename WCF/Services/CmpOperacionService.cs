using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class CmpOperacionService : ICmpOperacion
    {
        CmpOperacion srv = new CmpOperacion();

        public List<CmpOperacion> GetList(string idEmpresa, string idTipo)
        {
            List<CmpOperacion> _list = srv.GetList(idEmpresa, idTipo);
            return _list;
        }

        public CmpOperacion GetOne(string idEmpresa, string idTipo, string id)
        {
            CmpOperacion _one = srv.GetOne(idEmpresa, idTipo, id);
            return _one;
        }

        public string NullOne(CmpOperacion one, List<InvMovimiento> detail)
        {
            string _id = srv.NullOne(one, detail);
            return _id;
        }

        public string SetOne(CmpOperacion one, List<InvMovimiento> detail)
        {
            string _id = srv.SetOne(one,detail);
            return _id;
        }
    }
}
