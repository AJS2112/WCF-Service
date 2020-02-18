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
    public class SisOperacion
    {
        #region PROPIEDADES
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public int order_id { get; set; }
        [DataMember]
        public int last_update { get; set; }
        [DataMember]
        public string id_tipo { get; set; }
        [DataMember]
        public string tipo_nombre { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string nombre_display { get; set; }
        [DataMember]
        public string descrip { get; set; }
        [DataMember]
        public string signo_inventario { get; set; }
        [DataMember]
        public string signo_caja { get; set; }
        [DataMember]
        public bool es_fiscal { get; set; }
        [DataMember]
        public bool es_autorizado { get; set; }
        [DataMember]
        public bool es_visible { get; set; }
        [DataMember]
        public bool es_derivado { get; set; }
        [DataMember]
        public bool es_transporte { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private SisOperacion Asignar(DataRow registro)
        {
            SisOperacion one = new SisOperacion();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_tipo = registro["id_tipo"].ToString();
            one.tipo_nombre= registro["tipo_nombre"].ToString();
            one.nombre = registro["nombre"].ToString();
            one.nombre_display = registro["nombre_display"].ToString();
            one.descrip = registro["descrip"].ToString();
            one.signo_inventario = registro["signo_inventario"].ToString();
            one.signo_caja = registro["signo_caja"].ToString();
            one.es_fiscal = Convert.ToBoolean((sbyte)registro["es_fiscal"]);
            one.es_autorizado = Convert.ToBoolean((sbyte)registro["es_autorizado"]);
            one.es_visible = Convert.ToBoolean((sbyte)registro["es_visible"]);
            one.es_derivado = Convert.ToBoolean((sbyte)registro["es_derivado"]);
            one.es_transporte = Convert.ToBoolean((sbyte)registro["es_transporte"]);

            return one;
        }

        public List<SisOperacion> GetList(string idTipo)
        {
            parametros.id_tipo= idTipo;
            DataTable miTabla = myHandler.Consulta("sistema_operaciones_SEL", parametros);

            List<SisOperacion> miLista = new List<SisOperacion>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                SisOperacion one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public SisOperacion GetOne(string id)
        {
            SisOperacion one = new SisOperacion();
            if (id == "0")
            {
                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.id_tipo = "";
                one.tipo_nombre = "";
                one.nombre = "";
                one.nombre_display = "";
                one.descrip = "";
                one.signo_inventario = "";
                one.signo_caja = "";
                one.es_fiscal = false;
                one.es_autorizado = false;
                one.es_visible = false;
                one.es_derivado = false;
                one.es_transporte = false;
            }
            else
            {
                parametros.id = id;
                DataTable miTabla = myHandler.Consulta("sistema_operaciones_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];
                one = Asignar(miRegistro);
            }
            return one;
        }

        public string SetOne(SisOperacion one)
        {
            string procedureName = "";
            string response = "";
            bool res = false;

            //CONFIGURA PARAMETROS
            parametros.id = one.id;
            parametros.order_id = one.order_id;
            parametros.last_update = one.last_update;
            parametros.id_tipo = one.id_tipo ;
            parametros.nombre = one.nombre;
            parametros.nombre_display = one.nombre_display ;
            parametros.descrip = one.descrip;
            parametros.signo_inventario = one.signo_inventario;
            parametros.signo_caja = one.signo_caja;
            parametros.es_fiscal = one.es_fiscal ;
            parametros.es_autorizado = one.es_autorizado ;
            parametros.es_visible = one.es_visible ;
            parametros.es_derivado = one.es_derivado ;
            parametros.es_transporte = one.es_transporte ;

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
                        procedureName = "sistema_operaciones_INS";
                    }
                    else
                    {
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        procedureName = "sistema_operaciones_UPD";
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

        #endregion
    }
}
