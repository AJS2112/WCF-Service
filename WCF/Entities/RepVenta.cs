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
    public class RepVenta
    {
        #region PROPIEDADES
        [DataMember]
        public string nro_control { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public string cliente_nombre { get; set; }
        [DataMember]
        public string cliente_rif { get; set; }
        [DataMember]
        public string tipo_operacion_nombre { get; set; }
        [DataMember]
        public string nro_control_documento { get; set; }
        [DataMember]
        public string nro_documento { get; set; }
        [DataMember]
        public DateTime fecha_documento { get; set; }
        [DataMember]
        public double cotizacion_valor { get; set; }
        [DataMember]
        public double monto { get; set; }
        [DataMember]
        public double cantidad { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public double abonos { get; set; }
        [DataMember]
        public double deuda { get; set; }
        [DataMember]
        public string instrumento_nombre { get; set; }
        [DataMember]
        public string nro_referencia { get; set; }
        [DataMember]
        public string moneda_descrip { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        public List<RepVenta> GetResumenOperaciones(string idEmpresa, string id_moneda, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reportes_ventas_operaciones_resumen", parametros);

            List<RepVenta> miLista = new List<RepVenta>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepVenta one = new RepVenta();
                one.tipo_operacion_nombre = miRegistro["nombre"].ToString();
                one.cantidad = Convert.ToDouble(miRegistro["cantidad"]);
                one.cotizacion_valor = Convert.ToDouble(miRegistro["cotizacion_valor"]);
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepVenta> GetDetalleOperaciones(string idEmpresa, string id_moneda, string id_tipo, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.id_tipo = id_tipo;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reportes_ventas_operaciones_detalle", parametros);

            List<RepVenta> miLista = new List<RepVenta>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepVenta one = new RepVenta();
                one.nro_control = miRegistro["nro_control"].ToString();
                one.fecha = DateTime.Parse(miRegistro["fecha"].ToString());
                one.cliente_nombre = miRegistro["cliente_nombre"].ToString();
                one.cliente_rif = miRegistro["cliente_rif"].ToString();
                one.tipo_operacion_nombre = miRegistro["tipo_documento_nombre"].ToString();
                one.nro_control_documento = miRegistro["nro_control_documento"].ToString();
                one.nro_documento = miRegistro["nro_documento"].ToString();
                one.fecha_documento = DateTime.Parse(miRegistro["fecha_documento"].ToString());
                one.cotizacion_valor = Convert.ToDouble(miRegistro["cotizacion_valor"]);
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepVenta> GetClienteOperaciones(string idEmpresa, string id_moneda, string id_cliente, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.id_cliente = id_cliente;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reportes_ventas_clientes_detalle", parametros);

            List<RepVenta> miLista = new List<RepVenta>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepVenta one = new RepVenta();
                one.nro_control = miRegistro["nro_control"].ToString();
                one.fecha = DateTime.Parse(miRegistro["fecha"].ToString());
                one.cliente_nombre = miRegistro["cliente_nombre"].ToString();
                one.cliente_rif = miRegistro["cliente_rif"].ToString();
                one.tipo_operacion_nombre = miRegistro["operacion_nombre"].ToString();
                one.nro_control_documento = miRegistro["nro_control_documento"].ToString();
                one.nro_documento = miRegistro["nro_documento"].ToString();
                one.fecha_documento = DateTime.Parse(miRegistro["fecha_documento"].ToString());
                one.cotizacion_valor = Convert.ToDouble(miRegistro["cotizacion_valor"]);
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepVenta> GetClientesDeudasResumen(string idEmpresa, string id_moneda)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;

            DataTable miTabla = myHandler.Consulta("reportes_ventas_deudas_resumen", parametros);

            List<RepVenta> miLista = new List<RepVenta>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepVenta one = new RepVenta();
                one.cliente_nombre = miRegistro["nombre"].ToString();
                one.cliente_rif = miRegistro["rif"].ToString();
                one.monto = Convert.ToDouble(miRegistro["total_moneda"]);
                one.abonos = Convert.ToDouble(miRegistro["abonos_moneda"]);
                one.deuda = Convert.ToDouble(miRegistro["deuda_moneda"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepVenta> GetClientesDeudasDetalle(string idEmpresa, string id_moneda, string id_cliente)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.id_cliente = id_cliente;

            DataTable miTabla = myHandler.Consulta("reportes_ventas_deudas_detalle", parametros);

            List<RepVenta> miLista = new List<RepVenta>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepVenta one = new RepVenta();
                one.cliente_nombre = miRegistro["cliente_nombre"].ToString();
                one.cliente_rif = miRegistro["cliente_rif"].ToString();
                one.tipo_operacion_nombre = miRegistro["tipo_documento_nombre"].ToString();
                one.nro_control_documento = miRegistro["nro_control"].ToString();
                one.nro_documento = miRegistro["numero"].ToString();
                one.fecha_documento = DateTime.Parse(miRegistro["fecha"].ToString());
                one.cotizacion_valor = Convert.ToDouble(miRegistro["cotizacion_valor"]);
                one.monto = Convert.ToDouble(miRegistro["total_moneda"]);
                one.abonos = Convert.ToDouble(miRegistro["abonos_moneda"]);
                one.deuda = Convert.ToDouble(miRegistro["deuda_moneda"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepVenta> GetClientesPagosRecibidos(string idEmpresa, string id_cliente, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_cliente = id_cliente;
            parametros.desde = desde;
            parametros.hasta = hasta;
            DataTable miTabla = myHandler.Consulta("reportes_ventas_pagos_detalle", parametros);

            List<RepVenta> miLista = new List<RepVenta>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepVenta one = new RepVenta();
                one.cliente_nombre = miRegistro["cliente_nombre"].ToString();
                one.cliente_rif = miRegistro["cliente_rif"].ToString();
                one.tipo_operacion_nombre = miRegistro["tipo_operacion_nombre"].ToString();
                one.nro_control_documento = miRegistro["nro_control"].ToString();
                one.fecha_documento = DateTime.Parse(miRegistro["fecha"].ToString());
                one.instrumento_nombre= miRegistro["instrumento_nombre"].ToString();
                one.nro_referencia= miRegistro["numero_operacion"].ToString();
                one.moneda_descrip = miRegistro["moneda_descrip"].ToString();
                one.cotizacion_valor = Convert.ToDouble(miRegistro["factor"]);
                one.monto = Convert.ToDouble(miRegistro["monto_moneda"]);
                miLista.Add(one);
            }
            return miLista;
        }

        #endregion
    }
}
