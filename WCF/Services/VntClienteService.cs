using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class VntClienteService : IVntCliente
    {
        VntCliente srv = new VntCliente();
        public List<VntCliente> GetList(string idEmpresa)
        {
            List<VntCliente> _list = srv.GetList(idEmpresa);
            return _list;
        }

        public VntCliente GetOne(string idEmpresa, string id)
        {
            VntCliente _one = srv.GetOne(idEmpresa, id);
            return _one;
        }

        public string SetOne(VntCliente one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
