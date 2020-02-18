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
    public class ColMovimiento
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
        public string id_tipo_operacion { get; set; }
        [DataMember]
        public string id_operacion { get; set; }
        [DataMember]
        public string id_producto { get; set; }
        [DataMember]
        public string producto_codigo { get; set; }
        [DataMember]
        public string producto_nombre { get; set; }
        [DataMember]
        public string producto_unidad { get; set; }
        [DataMember]
        public string id_impuesto { get; set; }
        [DataMember]
        public double cantidad { get; set; }
        [DataMember]
        public double costo { get; set; }
        [DataMember]
        public double precio { get; set; }
        [DataMember]
        public double valor_impuesto { get; set; }
        [DataMember]
        public double monto { get; set; }
        [DataMember]
        public double monto_impuesto { get; set; }
        [DataMember]
        public double costo_moneda { get; set; }
        [DataMember]
        public double precio_moneda { get; set; }
        [DataMember]
        public double monto_moneda { get; set; }
        [DataMember]
        public double monto_impuesto_moneda { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private ColMovimiento Asignar(DataRow registro)
        {
            ColMovimiento one = new ColMovimiento();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_empresa = registro["id_empresa"].ToString();
            one.id_tipo_operacion = registro["id_tipo_operacion"].ToString();
            one.id_operacion = registro["id_operacion"].ToString();
            one.id_producto = registro["id_producto"].ToString();
            one.producto_codigo = registro["producto_codigo"].ToString();
            one.producto_nombre = registro["producto_nombre"].ToString();
            one.producto_unidad = registro["producto_unidad"].ToString();
            one.costo = (double)registro["costo"];
            one.precio = (double)registro["precio"];
            one.cantidad = (double)registro["cantidad"];
            one.id_impuesto = registro["id_impuesto"].ToString();
            one.valor_impuesto = (double)registro["valor_impuesto"];
            one.monto = (double)registro["monto"];
            one.monto_impuesto = (double)registro["monto_impuesto"];
            one.costo_moneda = (double)registro["costo_moneda"];
            one.precio_moneda = (double)registro["precio_moneda"];
            one.monto_moneda = Convert.ToDouble(registro["monto_moneda"]);
            one.monto_impuesto_moneda = Convert.ToDouble(registro["monto_impuesto_moneda"]);


            return one;
        }

        public bool Delete(string idOperacion)
        {
            try
            {
                parametros.id_operacion = idOperacion;
                DataTable miTabla = myHandler.Consulta("cola_operaciones_detail_DEL", parametros);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<ColMovimiento> GetList(string idOperacion)
        {
            parametros.id_operacion = idOperacion;
            DataTable miTabla = myHandler.Consulta("cola_operaciones_detail_SEL", parametros);

            List<ColMovimiento> miLista = new List<ColMovimiento>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                ColMovimiento one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public string SetOne(ColMovimiento one)
        {
            string procedureName = "";
            string response = "";
            bool res = false;

            //CONFIGURA PARAMETROS
            parametros.id = one.id;
            parametros.order_id = one.order_id;
            parametros.last_update = one.last_update;
            parametros.id_empresa = one.id_empresa;
            parametros.id_tipo_operacion = one.id_tipo_operacion;
            parametros.id_operacion = one.id_operacion;
            parametros.id_producto = one.id_producto;
            parametros.costo = one.costo;
            parametros.precio = one.precio;
            parametros.cantidad = one.cantidad;
            parametros.id_impuesto = one.id_impuesto;
            parametros.valor_impuesto = one.valor_impuesto;

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
                    }
                    procedureName = "cola_operaciones_detail_INS";
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

        #endregion
    }
}
