using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class CmpProveedorService : ICmpProveedor
    {
        CmpProveedor srv = new CmpProveedor();

        public List<CmpProveedor> GetList(string idEmpresa)
        {
            List<CmpProveedor> _list = srv.GetList(idEmpresa);
            return _list;
        }

        public CmpProveedor GetOne(string idEmpresa, string id)
        {
            CmpProveedor _one = srv.GetOne(idEmpresa, id);
            return _one;
        }

        public string SetOne(CmpProveedor one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
