using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class RepCompraService : IRepCompra
    {
        RepCompra srv = new RepCompra();

        public List<RepCompra> GetDetalleOperaciones(string idEmpresa, string id_moneda, string id_tipo, string desde, string hasta)
        {
            List<RepCompra> _list = srv.GetDetalleOperaciones(idEmpresa, id_moneda, id_tipo, desde, hasta);
            return _list;
        }

        public List<RepCompra> GetProveedorOperaciones(string idEmpresa, string id_moneda, string id_proveedor, string desde, string hasta)
        {
            List<RepCompra> _list = srv.GetProveedorOperaciones(idEmpresa, id_moneda, id_proveedor, desde, hasta);
            return _list;
        }

        public List<RepCompra> GetResumenOperaciones(string idEmpresa, string id_moneda, string desde, string hasta)
        {
            List<RepCompra> _list = srv.GetResumenOperaciones(idEmpresa, id_moneda, desde, hasta);
            return _list;
        }
    }
}
