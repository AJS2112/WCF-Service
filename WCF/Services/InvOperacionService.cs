using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class InvOperacionService : IInvOperacion
    {
        InvOperacion srv = new InvOperacion();
        public List<InvOperacion> GetList(string idEmpresa, string idTipo)
        {
            List<InvOperacion> _list = srv.GetList(idEmpresa, idTipo);
            return _list;
        }

        public InvOperacion GetOne(string idEmpresa, string idTipo, string id)
        {
            InvOperacion _one = srv.GetOne(idEmpresa, idTipo, id);
            return _one;
        }

        public string NullOne(InvOperacion one, List<InvMovimiento> detail)
        {
            string _id = srv.NullOne(one, detail);
            return _id;
        }

        public string SetOne(InvOperacion one, List<InvMovimiento> detail)
        {
            string _id = srv.SetOne(one, detail);
            return _id;
        }
    }
}
