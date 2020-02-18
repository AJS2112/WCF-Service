using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class InvCategoriaService : IInvCategoria
    {
        InvCategoria srv = new InvCategoria();
        public List<InvCategoria> GetList(string idEmpresa)
        {
            List<InvCategoria> _list = srv.GetList(idEmpresa);
            return _list;
        }

        public InvCategoria GetOne(string idEmpresa, string id)
        {
            InvCategoria _one = srv.GetOne(idEmpresa, id);
            return _one;
        }

        public string SetOne(InvCategoria one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
