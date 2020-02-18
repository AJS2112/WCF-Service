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
    public class SisEmpresa
    {
        #region PROPIEDADES
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public int order_id { get; set; }
        [DataMember]
        public int last_update { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string rif { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public bool es_inactivo { get; set; }
        [DataMember]
        public string monedas { get; set; }
        [DataMember]
        public string moneda_defecto { get; set; }
        [DataMember]
        public string instrumentos_pago { get; set; }
        [DataMember]
        public bool es_modo_fiscal { get; set; }
        [DataMember]
        public double pct_fiscal { get; set; }
        [DataMember]
        public DateTime fecha_contrato { get; set; }
        #endregion

        #region METODOS
        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();
        

        public SisEmpresa GetOne(string id)
        {
            SisEmpresa one = new SisEmpresa();
            if (id == "0")
            {
                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.nombre = "";
                one.rif = "";
                one.direccion = "";
                one.telefono = "";
                one.es_inactivo = false;
                one.moneda_defecto = "0";
                one.monedas = "";
                one.instrumentos_pago = "";
                one.es_modo_fiscal = false;
                one.pct_fiscal = 0;
                one.fecha_contrato = new DateTime();
                
            }
            else
            {
                parametros.id= id;
                DataTable miTabla = myHandler.Consulta("sistema_empresas_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];

                one.id = miRegistro["id"].ToString();
                one.order_id = (int) miRegistro["order_id"];
                one.last_update = (int) miRegistro["last_update"];
                one.nombre = miRegistro["nombre"].ToString();
                one.rif = miRegistro["rif"].ToString();
                one.direccion = miRegistro["direccion"].ToString();
                one.telefono = miRegistro["telefono"].ToString();
                one.es_inactivo = Convert.ToBoolean((sbyte) miRegistro["es_inactivo"]);
                one.moneda_defecto = miRegistro["moneda_defecto"].ToString();
                one.monedas= miRegistro["monedas"].ToString();
                one.instrumentos_pago = miRegistro["instrumentos_pago"].ToString();
                one.es_modo_fiscal= Convert.ToBoolean((sbyte)miRegistro["es_modo_fiscal"]);
                one.pct_fiscal = (double)miRegistro["pct_fiscal"];
                if (miRegistro["fecha_contrato"].ToString().Length==0)
                {
                    one.fecha_contrato = new DateTime();
                }else
                {
                    one.fecha_contrato = Convert.ToDateTime(miRegistro["fecha_contrato"]);
                }

            }

            return one;
        }

        public string SetOne(SisEmpresa one)
        {
            string procedureName = "";
            string response = "";
            bool res = false;
            //parametros = one.ToExpandoObject();
            //CONFIGURA PARAMETROS
            parametros.id = one.id;
            parametros.order_id = one.order_id;
            parametros.last_update = one.last_update;
            parametros.nombre = one.nombre;
            parametros.rif = one.rif;
            parametros.direccion = one.direccion;
            parametros.telefono = one.telefono;
            parametros.es_inactivo = one.es_inactivo;
            parametros.monedas = one.monedas;
            parametros.moneda_defecto = one.moneda_defecto;
            parametros.instrumentos_pago = one.instrumentos_pago;
            parametros.es_modo_fiscal = one.es_modo_fiscal;
            parametros.pct_fiscal = one.pct_fiscal;
            parametros.fecha_contrato = one.fecha_contrato;
            try
            {
                if (one.id == "0")
                {
                    procedureName = "sistema_empresas_INS";
                    DataTable miTabla = myHandler.Consulta("getUUID", null);
                    if (miTabla.Rows.Count != 0)
                    {
                        DataRow miRegistro = miTabla.Rows[0];

                        parametros.id = miRegistro["id"].ToString();
                        parametros.order_id = Convert.ToInt32(miRegistro["order_id"]);
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                    }
                }
                else
                {
                    procedureName = "sistema_empresas_UPD";
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
