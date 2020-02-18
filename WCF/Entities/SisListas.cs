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
    public class SisListas
    {
        #region PROPIEDADES
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public int order_id { get; set; }
        [DataMember]
        public int last_update { get; set; }
        [DataMember]
        public string campo { get; set; }
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

        private SisListas Asignar(DataRow registro)
        {
            SisListas one = new SisListas();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.campo = registro["campo"].ToString();
            one.nombre = registro["nombre"].ToString();
            one.descrip = registro["descrip"].ToString();
            one.id_padre = registro["id_padre"].ToString();

            return one;
        }

        public List<SisListas> GetList(string id)
        {
            parametros.id = id;
            DataTable miTabla = myHandler.Consulta("sistema_listas_SEL", parametros);

            List<SisListas> miLista = new List<SisListas>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                SisListas one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }
        public List<SisListas> GetListByCampo(string campo)
        {
            parametros.campo= campo;
            DataTable miTabla = myHandler.Consulta("sistema_listas_SELBYCAMPO", parametros);

            List<SisListas> miLista = new List<SisListas>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                SisListas one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }
        public SisListas GetOne(string idEmpresa, string id)
        {
            SisListas one = new SisListas();
            if (id == "0")
            {
                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.campo= "";
                one.nombre = "";
                one.descrip = "";
                one.id_padre = "";
            }
            else
            {
                parametros.id_empresa = idEmpresa;
                parametros.id = id;
                DataTable miTabla = myHandler.Consulta("compras_proveedores_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];
                one = Asignar(miRegistro);
            }
            return one;
        }

        public string SetOne(SisListas one)
        {
            string procedureName = "";
            string response = "";
            bool res = false;

            //CONFIGURA PARAMETROS
            parametros.id = one.id;
            parametros.order_id = one.order_id;
            parametros.last_update = one.last_update;
            parametros.campo = one.campo;
            parametros.nombre = one.nombre;
            parametros.descrip = one.descrip;
            parametros.id_padre= one.id_padre;

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
                        procedureName = "sistema_listas_INS";
                    }
                    else
                    {
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        procedureName = "sistema_listas_UPD";
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
