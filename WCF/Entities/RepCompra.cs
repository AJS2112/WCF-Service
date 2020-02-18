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
    public class RepCompra
    {
        #region PROPIEDADES
        [DataMember]
        public string nro_control { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public string proveedor_nombre { get; set; }
        [DataMember]
        public string proveedor_rif { get; set; }
        [DataMember]
        public string tipo_documento_nombre { get; set; }
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
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        public List<RepCompra> GetResumenOperaciones(string idEmpresa, string id_moneda, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reportes_compras_operaciones_resumen", parametros);

            List<RepCompra> miLista = new List<RepCompra>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepCompra one = new RepCompra();
                one.nombre = miRegistro["nombre"].ToString();
                one.cantidad = Convert.ToDouble(miRegistro["cantidad"]);
                one.cotizacion_valor = Convert.ToDouble(miRegistro["cotizacion_valor"]);
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepCompra> GetDetalleOperaciones(string idEmpresa, string id_moneda, string id_tipo, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda= id_moneda;
            parametros.id_tipo = id_tipo;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reportes_compras_operaciones_detalle", parametros);

            List<RepCompra> miLista = new List<RepCompra>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepCompra one = new RepCompra();
                one.nro_control = miRegistro["nro_control"].ToString();
                one.fecha = DateTime.Parse(miRegistro["fecha"].ToString());
                one.proveedor_nombre = miRegistro["proveedor_nombre"].ToString();
                one.proveedor_rif = miRegistro["proveedor_rif"].ToString();
                one.tipo_documento_nombre = miRegistro["tipo_documento_nombre"].ToString();
                one.nro_control_documento = miRegistro["nro_control_documento"].ToString();
                one.nro_documento = miRegistro["nro_documento"].ToString();
                one.fecha_documento = DateTime.Parse(miRegistro["fecha_documento"].ToString());
                one.cotizacion_valor = Convert.ToDouble(miRegistro["cotizacion_valor"]);
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepCompra> GetProveedorOperaciones(string idEmpresa, string id_moneda, string id_proveedor, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_moneda = id_moneda;
            parametros.id_proveedor = id_proveedor;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reportes_compras_proveedores_detalle", parametros);

            List<RepCompra> miLista = new List<RepCompra>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepCompra one = new RepCompra();
                one.nro_control = miRegistro["nro_control"].ToString();
                one.fecha = DateTime.Parse(miRegistro["fecha"].ToString());
                one.proveedor_nombre = miRegistro["proveedor_nombre"].ToString();
                one.proveedor_rif = miRegistro["proveedor_rif"].ToString();
                one.tipo_documento_nombre = miRegistro["operacion_nombre"].ToString();
                one.nro_control_documento = miRegistro["nro_control_documento"].ToString();
                one.nro_documento = miRegistro["nro_documento"].ToString();
                one.fecha_documento = DateTime.Parse(miRegistro["fecha_documento"].ToString());
                one.cotizacion_valor = Convert.ToDouble(miRegistro["cotizacion_valor"]);
                one.monto = Convert.ToDouble(miRegistro["monto"]);
                miLista.Add(one);
            }
            return miLista;
        }



        #endregion
    }
}
