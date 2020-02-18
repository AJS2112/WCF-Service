using DAL;
using Newtonsoft.Json.Linq;
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
    public static class SisSync
    {

        #region METODOS
        static DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private static dynamic parametros = new System.Dynamic.ExpandoObject();


        public static void SaveSQL(string NombreSP, dynamic _parametros)
        {
            //dynamic parametros = new System.Dynamic.ExpandoObject();
            IDictionary<string, object> misParametros = _parametros;
            string cadena = "";
            foreach (var property in misParametros.Keys)
            {
                cadena += "?,";
            }

            DataTable miTabla = myHandler.Consulta("getUUID", null);
            if (miTabla.Rows.Count != 0)
            {
                DataRow miRegistro = miTabla.Rows[0];

                parametros.id = miRegistro["id"].ToString();
                parametros.order_id = Convert.ToInt32(miRegistro["order_id"]);
                parametros.sql_string = "";
                parametros.procedure_name = NombreSP+ "(" + cadena.Remove(cadena.Length - 1, 1) + ")";
                parametros.parameters = Newtonsoft.Json.JsonConvert.SerializeObject(_parametros);

                myHandler.Comando("sistema_sync_INS", parametros);
            }
        }
        #endregion
    }
}
