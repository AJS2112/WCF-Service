using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class RepInventarioService : IRepInventario
    {
        RepInventario srv = new RepInventario();

        public List<RepInventario> GetDetalleMovimientos(string idEmpresa, string id_producto, string desde, string hasta)
        {
            List<RepInventario> _list = srv.GetDetalleMovimientos(idEmpresa,id_producto,desde,hasta);
            return _list;
        }

        public List<RepInventario> GetResumenMovimientos(string idEmpresa, string id_categoria, string desde, string hasta)
        {
            List<RepInventario> _list = srv.GetResumenMovimientos(idEmpresa,id_categoria,desde,hasta);
            return _list;
        }
    }
}
