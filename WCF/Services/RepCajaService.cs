using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class RepCajaService : IRepCaja
    {

        RepCaja srv = new RepCaja();

        public List<RepCaja> GetCuentasDetalle(string idEmpresa, string id_moneda, string id_cuenta, string desde, string hasta)
        {
            List<RepCaja> _list = srv.GetCuentasDetalle(idEmpresa, id_moneda, id_cuenta, desde, hasta);
            return _list;
        }

        public List<RepCaja> GetCuentasResumen(string idEmpresa, string id_moneda, string desde, string hasta)
        {
            List<RepCaja> _list = srv.GetCuentasResumen(idEmpresa, id_moneda, desde, hasta);
            return _list;
        }

        public List<RepCaja> GetInstrumentosDetalle(string idEmpresa, string id_moneda, string id_instrumento, string desde, string hasta)
        {
            List<RepCaja> _list = srv.GetInstrumentosDetalle(idEmpresa, id_moneda, id_instrumento, desde, hasta);
            return _list;
        }

        public List<RepCaja> GetInstrumentosResumen(string idEmpresa, string id_moneda, string desde, string hasta)
        {
            List<RepCaja> _list = srv.GetInstrumentosResumen(idEmpresa, id_moneda, desde, hasta);
            return _list;
        }
    }
}
