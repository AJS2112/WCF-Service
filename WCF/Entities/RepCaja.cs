using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Entities
{
    [DataContract]
    public class RepCaja {
        #region PROPIEDADES
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public string instrumento_nombre { get; set; }
        [DataMember]
        public string nro_operacion { get; set; }
        [DataMember]
        public string operacion_nombre { get; set; }
        [DataMember]
        public string nro_control { get; set; }
        [DataMember]
        public string cliente_nombre { get; set; }
        [DataMember]
        public string cliente_rif { get; set; }
        [DataMember]
        public double cotizacion_valor { get; set; }
        [DataMember]
        public double monto { get; set; }
        [DataMember]
        public string cuenta_numero { get; set; }
        [DataMember]
        public string banco_nombre { get; set; }
        [DataMember]
        public double cantidad { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        public List<RepCaja> GetCuentasDetalle(string idEmpresa, string id_moneda, string id_cuenta, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.id_cuenta = id_cuenta;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reporte_caja_cuentas_detalle", parametros);

            List<RepCaja> miLista = new List<RepCaja>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepCaja one = new RepCaja();
                //one.cuenta_numero = miRegistro["cuenta_numero "].ToString();
                one.banco_nombre= miRegistro["banco_nombre"].ToString();
                one.fecha = DateTime.Parse(miRegistro["fecha"].ToString());
                one.instrumento_nombre = miRegistro["instrumento_nombre"].ToString();
                one.nro_operacion = miRegistro["numero_operacion"].ToString();
                one.operacion_nombre = miRegistro["operacion_nombre"].ToString();
                one.nro_control= miRegistro["nro_control"].ToString();
                one.cliente_nombre = miRegistro["cliente_nombre"].ToString();
                one.cliente_rif = miRegistro["cliente_rif"].ToString();
                one.cotizacion_valor = Convert.ToDouble(miRegistro["cotizacion_valor"]);
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepCaja> GetCuentasResumen(string idEmpresa, string id_moneda, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reporte_caja_cuentas_resumen", parametros);

            List<RepCaja> miLista = new List<RepCaja>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepCaja one = new RepCaja();
                one.cuenta_numero = miRegistro["cuenta_numero"].ToString();
                one.banco_nombre = miRegistro["banco_nombre"].ToString();
                one.cantidad= Convert.ToDouble(miRegistro["cantidad"]);
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepCaja> GetInstrumentosDetalle(string idEmpresa, string id_moneda, string id_instrumento, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.id_instrumento = id_instrumento;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reporte_caja_instrumentos_detalle", parametros);

            List<RepCaja> miLista = new List<RepCaja>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepCaja one = new RepCaja();
                one.instrumento_nombre = miRegistro["instrumento_nombre"].ToString();
                one.fecha = DateTime.Parse(miRegistro["fecha"].ToString());
                one.nro_operacion= miRegistro["numero_operacion"].ToString();
                one.operacion_nombre = miRegistro["operacion_nombre"].ToString();
                one.nro_control = miRegistro["nro_control"].ToString();
                one.cliente_nombre = miRegistro["cliente_nombre"].ToString();
                one.cliente_rif = miRegistro["cliente_rif"].ToString();
                one.cotizacion_valor = Convert.ToDouble(miRegistro["cotizacion_valor"]);
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepCaja> GetInstrumentosResumen(string idEmpresa, string id_moneda, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.desde= desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reporte_caja_instrumentos_resumen", parametros);

            List<RepCaja> miLista = new List<RepCaja>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepCaja one = new RepCaja();
                one.instrumento_nombre= miRegistro["instrumento_nombre"].ToString();
                one.cantidad = Convert.ToDouble(miRegistro["cantidad"].ToString());
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }


        #endregion
    }
}
