using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class CnfCotizacionService : ICnfCotizacion
    {
        CnfCotizacion srv = new CnfCotizacion();
        public List<CnfCotizacionDetalle> GetLast(string idEmpresa)
        {
            List<CnfCotizacionDetalle> _list = srv.GetLast(idEmpresa);
            return _list;
        }

        public List<CnfCotizacion> GetList(string idEmpresa)
        {
            List<CnfCotizacion> _list = srv.GetList(idEmpresa);
            return _list;
        }

        public CnfCotizacion GetOne(string idEmpresa, string id)
        {
            CnfCotizacion _one = srv.GetOne(idEmpresa, id);
            return _one;
        }
        public List<CnfCotizacionDetalle> GetListDetail(string idCotizacion)
        {
            List<CnfCotizacionDetalle> _list = srv.GetListDetail(idCotizacion);
            return _list;
        }

        public string SetOne(CnfCotizacion one, List<CnfCotizacionDetalle> detail)
        {
            string _id = srv.SetOne(one, detail);
            return _id;
        }
    }
}
