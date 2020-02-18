using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCF.Helpers;

namespace WCF.Entities
{
    [DataContract]
    public class InvProducto
    {
        #region PROPIEDADES
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public int order_id { get; set; }
        [DataMember]
        public int last_update { get; set; }
        [DataMember]
        public string id_empresa { get; set; }
        [DataMember]
        public string id_categoria { get; set; }
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string id_unidad { get; set; }
        [DataMember]
        public double cantidad_empaque { get; set; }
        [DataMember]
        public string id_impuesto { get; set; }
        [DataMember]
        public double costo { get; set; }
        [DataMember]
        public double precio { get; set; }
        [DataMember]
        public double pct_comision { get; set; }
        [DataMember]
        public double existencia { get; set; }
        [DataMember]
        public bool es_inactivo { get; set; }

        //PROPIEDADES CALCULADAS
        [DataMember]
        public double pct_utilidad { get; set; }
        
        

        //LISTA
        [DataMember]
        public string categoria_nombre { get; set; }
        [DataMember]
        public string unidad_nombre { get; set; }
        [DataMember]
        public double impuesto_valor { get; set; }
        [DataMember]
        public double costo_moneda { get; set; }
        [DataMember]
        public double precio_moneda { get; set; }


        //WEB
        [DataMember]
        public string imagen { get; set; }
        [DataMember]
        public string nombre_web { get; set; }
        [DataMember]
        public string descripcion_web { get; set; }
        [DataMember]
        public Int16 es_visible_web { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private InvProducto Asignar(DataRow registro)
        {
            InvProducto one = new InvProducto();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_empresa = registro["id_empresa"].ToString();
            one.id_categoria = registro["id_categoria"].ToString();
            one.codigo = registro["codigo"].ToString();
            one.nombre = registro["nombre"].ToString();
            one.id_unidad = registro["id_unidad"].ToString();
            one.cantidad_empaque = (double)registro["cantidad_empaque"];
            one.id_impuesto = registro["id_impuesto"].ToString();
            one.costo = (double)registro["costo"];
            one.pct_utilidad = (double)registro["pct_utilidad"];
            one.precio = (double)registro["precio"];
            one.pct_comision= (double)registro["pct_comision"];
            one.existencia = (double)registro["existencia"];
            one.es_inactivo = false;
            if (registro["es_inactivo"]!= System.DBNull.Value) one.es_inactivo = Convert.ToBoolean(registro["es_inactivo"]);

            one.categoria_nombre = registro["categoria_nombre"].ToString();
            one.unidad_nombre = registro["unidad_nombre"].ToString();
            one.impuesto_valor = (double)registro["impuesto_valor"];
            one.costo_moneda = (double)registro["costo_moneda"];
            one.precio_moneda = (double)registro["precio_moneda"];
            return one;
        }

        public List<InvProducto> GetList(string idEmpresa)
        {
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("inventario_productos_SEL", parametros);

            List<InvProducto> miLista = new List<InvProducto>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                InvProducto one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<InvProducto> GetListPV(string idEmpresa)
        {
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("inventario_productos_SELPV", parametros);

            List<InvProducto> miLista = new List<InvProducto>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                InvProducto one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public InvProducto GetOne(string idEmpresa, string id)
        {
            InvProducto one = new InvProducto();
            if (id == "0")
            {
                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.id_empresa = idEmpresa;
                one.id_categoria = "";
                one.codigo = "";
                one.nombre = "";
                one.id_unidad= "";
                one.cantidad_empaque = 1;
                one.id_impuesto = "";
                one.costo = 0;
                one.pct_utilidad = 0;
                one.precio = 0;
                one.existencia = 0;
                one.pct_comision = 0;
                one.es_inactivo = false;

                one.categoria_nombre = "";
                one.unidad_nombre = "";
                one.impuesto_valor = 0;
                one.costo_moneda = 0;
                one.precio_moneda = 0;

                one.imagen = "";
                one.nombre_web = "";
                one.descripcion_web = "";
                one.es_visible_web = 0;
            }
            else
            {
                parametros.id_empresa = idEmpresa;
                parametros.id = id;
                DataTable miTabla = myHandler.Consulta("inventario_productos_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];
                one = Asignar(miRegistro);
            }
            return one;
        }

        public string SetOne(InvProducto one)
        {
            string procedureName = "";
            string response = "";
            bool res = false;

            //CONFIGURA PARAMETROS
            parametros.id = one.id;
            parametros.order_id =one.order_id;
            parametros.last_update =one.last_update;
            parametros.id_empresa =one.id_empresa;
            parametros.id_categoria =one.id_categoria;
            parametros.codigo =one.codigo;
            parametros.nombre =one.nombre;
            parametros.id_unidad =one.id_unidad;
            parametros.cantidad_empaque = one.cantidad_empaque;
            parametros.id_impuesto =one.id_impuesto;
            parametros.costo =one.costo;
            parametros.precio =one.precio;
            parametros.existencia =one.existencia;
            parametros.pct_comision = one.pct_comision;
            parametros.es_inactivo = one.es_inactivo;

            parametros.imagen = one.imagen;
            parametros.nombre_web = one.nombre_web;
            parametros.descripcion_web = one.descripcion_web;
            parametros.es_visible_web = one.es_visible_web;

            try
            {
                DataTable miTabla = myHandler.Consulta("getUUID", null);
                if (miTabla.Rows.Count != 0)
                {
                    DataRow miRegistro = miTabla.Rows[0];

                    if (one.id == "0")
                    {
                        parametros.id = miRegistro["id"].ToString();
                        parametros.order_id = Convert.ToInt32(miRegistro["order_id"]);
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        procedureName = "inventario_productos_INS";

                    }
                    else
                    {
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        procedureName = "inventario_productos_UPD";
                    }
                }


                res = myHandler.Comando(procedureName, parametros);

                if (res)
                {
                    SisSync.SaveSQL(procedureName, parametros);
                    response = parametros.id;
                }
                else
                {
                    response = "";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateExistencia(string idProducto, string signo, double cantidad)
        {
            string procedureName = "";
            string response = "";
            bool res = false;

            //CONFIGURA PARAMETROS
            parametros.id = idProducto;
            parametros.signo= signo;
            parametros.cantidad = cantidad;

            try
            {
                procedureName = "inventario_productos_EXIST";
                res = myHandler.Comando(procedureName, parametros);

                if (res)
                {
                    SisSync.SaveSQL(procedureName, parametros);
                    response = parametros.id;
                }
                else
                {
                    response = "";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
