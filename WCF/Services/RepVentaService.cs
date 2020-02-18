using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class RepVentaService : IRepVenta
    {
        RepVenta srv = new RepVenta();
        public List<RepVenta> GetClienteDeudasDetalle(string idEmpresa, string id_moneda, string id_cliente)
        {
            List<RepVenta> _list = srv.GetClientesDeudasDetalle(idEmpresa, id_moneda, id_cliente);
            return _list;
        }

        public List<RepVenta> GetClienteDeudasResumen(string idEmpresa, string id_moneda)
        {
            List<RepVenta> _list = srv.GetClientesDeudasResumen(idEmpresa, id_moneda);
            return _list;
        }

        public List<RepVenta> GetClienteOperaciones(string idEmpresa, string id_moneda, string id_cliente, string desde, string hasta)
        {
            List<RepVenta> _list = srv.GetClienteOperaciones(idEmpresa, id_moneda, id_cliente, desde, hasta);
            return _list;
        }

        public List<RepVenta> GetClientePagosRecibidos(string idEmpresa, string id_cliente, string desde, string hasta)
        {
            List<RepVenta> _list = srv.GetClientesPagosRecibidos(idEmpresa, id_cliente, desde, hasta);
            return _list;
        }

        public List<RepVenta> GetDetalleOperaciones(string idEmpresa, string id_moneda, string id_tipo, string desde, string hasta)
        {
            List<RepVenta> _list = srv.GetDetalleOperaciones(idEmpresa, id_moneda, id_tipo, desde, hasta);
            return _list;
        }

        public List<RepVenta> GetResumenOperaciones(string idEmpresa, string id_moneda, string desde, string hasta)
        {
            List<RepVenta> _list = srv.GetResumenOperaciones(idEmpresa, id_moneda, desde, hasta);
            return _list;
        }
    }
}
