using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCF.Helpers;

namespace WCF.Entities
{
    [DataContract]
    public class InvCategoria
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
        public string nombre { get; set; }
        [DataMember]
        public string descrip { get; set; }
        [DataMember]
        public string id_padre { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        public List<InvCategoria> GetList(string idEmpresa)
        {
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("inventario_categorias_SEL", parametros);

            List<InvCategoria> miLista = new List<InvCategoria>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                InvCategoria one = new InvCategoria();
                one.id = miRegistro["id"].ToString();
                one.order_id = (int)miRegistro["order_id"];
                one.last_update= (int)miRegistro["last_update"];
                one.id_empresa = miRegistro["id_empresa"].ToString();
                one.nombre = miRegistro["nombre"].ToString();
                one.descrip = miRegistro["descrip"].ToString();
                one.id_padre = miRegistro["id_padre"].ToString();
                miLista.Add(one);
            }
            return miLista;
        }
        
        public InvCategoria GetOne(string idEmpresa, string id)
        {
            InvCategoria one = new InvCategoria();
            if (id == "0")
            {
                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.id_empresa = idEmpresa;
                one.nombre = "";
                one.descrip = "";
                one.id_padre = "00000000000000000000000000000000";
            }
            else
            {
                parametros.id_empresa = idEmpresa;
                parametros.id = id;
                DataTable miTabla = myHandler.Consulta("inventario_categorias_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];

                one.id = miRegistro["id"].ToString();
                one.order_id = (int)miRegistro["order_id"];
                one.last_update = (int)miRegistro["last_update"];
                one.id_empresa = miRegistro["id_empresa"].ToString();
                one.nombre = miRegistro["nombre"].ToString();
                one.descrip = miRegistro["descrip"].ToString();
                one.id_padre = miRegistro["id_padre"].ToString();
            }
            return one;
        }
        
        public string SetOne(InvCategoria one)
        {
            string procedureName = "";
            string response = "";
            bool res = false;
            parametros = one.ToExpandoObject();
            try
            {
                if (one.id == "0")
                {
                    procedureName = "inventario_categorias_INS";
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
                    procedureName = "inventario_categorias_UPD";
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
