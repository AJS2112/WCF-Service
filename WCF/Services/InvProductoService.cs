using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class InvProductoService : IInvProducto
    {
        InvProducto srv = new InvProducto();
        public List<InvProducto> GetList(string idEmpresa)
        {
            List<InvProducto> _list = srv.GetList(idEmpresa);
            return _list;
        }

        public List<InvProducto> GetListPV(string idEmpresa)
        {
            List<InvProducto> _list = srv.GetListPV(idEmpresa);
            return _list;
        }

        public InvProducto GetOne(string idEmpresa, string id)
        {
            InvProducto _one = srv.GetOne(idEmpresa, id);
            return _one;
        }

        public string SetOne(InvProducto one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
