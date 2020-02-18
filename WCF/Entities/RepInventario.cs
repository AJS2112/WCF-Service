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
    public class RepInventario
    {
        #region PROPIEDADES
        [DataMember]
        public string id_tipo { get; set; }
        [DataMember]
        public string tipo_nombre{ get; set; }
        [DataMember]
        public string operacion_nombre { get; set; }
        [DataMember]
        public string nro_control { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public string id_producto { get; set; }
        [DataMember]
        public string categoria_nombre { get; set; }
        [DataMember]
        public string producto_nombre { get; set; }
        [DataMember]
        public string producto_codigo { get; set; }
        [DataMember]
        public string producto_unidad { get; set; }
        [DataMember]
        public double total_entrada { get; set; }
        [DataMember]
        public double total_neutro { get; set; }
        [DataMember]
        public double total_salida { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        public List<RepInventario> GetResumenMovimientos(string idEmpresa, string id_categoria, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_categoria= id_categoria;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reporte_inventario_movimientos_resumen", parametros);

            List<RepInventario> miLista = new List<RepInventario>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepInventario one = new RepInventario();
                one.id_producto = miRegistro["id_producto"].ToString();
                one.categoria_nombre = miRegistro["categoria_nombre"].ToString();
                one.producto_nombre = miRegistro["producto_nombre"].ToString();
                one.producto_codigo = miRegistro["producto_codigo"].ToString();
                one.producto_unidad = miRegistro["producto_unidad"].ToString();
                one.total_entrada = Convert.ToDouble(miRegistro["total_entrada"]);
                one.total_neutro = Convert.ToDouble(miRegistro["total_neutro"]);
                one.total_salida = Convert.ToDouble(miRegistro["total_salida"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepInventario> GetDetalleMovimientos(string idEmpresa, string id_producto, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_producto = id_producto;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reporte_inventario_movimientos_detalle", parametros);

            List<RepInventario> miLista = new List<RepInventario>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepInventario one = new RepInventario();
                one.id_tipo = miRegistro["id_tipo"].ToString();
                one.tipo_nombre= miRegistro["tipo_nombre"].ToString();
                one.operacion_nombre= miRegistro["operacion_nombre"].ToString();
                one.nro_control= miRegistro["nro_control"].ToString();
                one.fecha= DateTime.Parse(miRegistro["fecha"].ToString());
                one.id_producto = miRegistro["id_producto"].ToString();
                one.categoria_nombre = miRegistro["categoria_nombre"].ToString();
                one.producto_nombre = miRegistro["producto_nombre"].ToString();
                one.producto_codigo = miRegistro["producto_codigo"].ToString();
                one.producto_unidad = miRegistro["producto_unidad"].ToString();
                one.total_entrada = Convert.ToDouble(miRegistro["total_entrada"]);
                one.total_neutro = Convert.ToDouble(miRegistro["total_neutro"]);
                one.total_salida = Convert.ToDouble(miRegistro["total_salida"]);
                miLista.Add(one);
            }
            return miLista;
        }




        #endregion
    }
}
