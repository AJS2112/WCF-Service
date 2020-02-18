using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class VntOperacionService : IVntOperacion
    {
        VntOperacion srv = new VntOperacion();

        public List<VntOperacion> GetDeudasCliente(string idCliente)
        {
            List<VntOperacion> _list = srv.GetDeudasCliente(idCliente);
            return _list;
        }

        public List<VntOperacion> GetList(string idEmpresa, string idTipo)
        {
            List<VntOperacion> _list = srv.GetList(idEmpresa, idTipo);
            return _list;
        }

        public VntOperacion GetOne(string idEmpresa, string idTipo, string id)
        {
            VntOperacion _one = srv.GetOne(idEmpresa, idTipo, id);
            return _one;
        }

        public string NullOne(VntOperacion one, List<InvMovimiento> detail)
        {
            string _id = srv.NullOne(one, detail);
            return _id;
        }

        public string SetAbono(VntOperacion one, List<CajMovimiento> pago)
        {
            string _id = srv.SetAbono(one, pago);
            return _id;
        }

        public string SetOne(VntOperacion one, List<InvMovimiento> detail, List<CajMovimiento> pago)
        {
            string _id = srv.SetOne(one, detail, pago);
            return _id;
        }
    }
}
