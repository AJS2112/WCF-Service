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
    public class CnfCuentaBancaria
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
        public string id_banco { get; set; }
        [DataMember]
        public string banco_nombre { get; set; }
        [DataMember]
        public string numero { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        public List<CnfCuentaBancaria> GetList(string idEmpresa)
        {
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("listas_cuentas_bancarias_SEL", parametros);

            List<CnfCuentaBancaria> miLista = new List<CnfCuentaBancaria>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                CnfCuentaBancaria one = new CnfCuentaBancaria();
                one.id = miRegistro["id"].ToString();
                one.order_id = (int)miRegistro["order_id"];
                one.last_update = (int)miRegistro["last_update"];
                one.id_empresa = miRegistro["id_empresa"].ToString();
                one.id_banco= miRegistro["id_banco"].ToString();
                one.banco_nombre = miRegistro["banco_nombre"].ToString();
                one.numero = miRegistro["numero"].ToString();
                miLista.Add(one);
            }
            return miLista;
        }

        public CnfCuentaBancaria GetOne(string idEmpresa, string id)
        {
            CnfCuentaBancaria one = new CnfCuentaBancaria();
            if (id == "0")
            {
                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.id_empresa = idEmpresa;
                one.id_banco = "";
                one.banco_nombre = "";
                one.numero = "00000000000000000000000000000000";
            }
            else
            {
                parametros.id_empresa = idEmpresa;
                parametros.id = id;
                DataTable miTabla = myHandler.Consulta("listas_cuentas_bancarias_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];

                one.id = miRegistro["id"].ToString();
                one.order_id = (int)miRegistro["order_id"];
                one.last_update = (int)miRegistro["last_update"];
                one.id_empresa = miRegistro["id_empresa"].ToString();
                one.id_banco = miRegistro["id_banco"].ToString();
                one.banco_nombre = miRegistro["banco_nombre"].ToString();
                one.numero = miRegistro["numero"].ToString();
            }
            return one;
        }

        public string SetOne(CnfCuentaBancaria one)
        {
            string procedureName = "";
            string response = "";
            bool res = false;
            //parametros = one.ToExpandoObject();
            //CONFIGURA PARAMETROS
            parametros.id = one.id;
            parametros.order_id = one.order_id;
            parametros.last_update = one.last_update;
            parametros.id_empresa = one.id_empresa;
            parametros.id_banco = one.id_banco;
            parametros.numero = one.numero;
            try
            {
                if (one.id == "0")
                {
                    procedureName = "listas_cuentas_bancarias_INS";
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
                    procedureName = "listas_cuentas_bancarias_UPD";
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
