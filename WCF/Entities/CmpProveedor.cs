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
    public class CmpProveedor
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
        public string nombre{ get; set; }
        [DataMember]
        public string rif { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string representante { get; set; }
        [DataMember]
        public string id_banco { get; set; }
        [DataMember]
        public string banco_nombre { get; set; }
        [DataMember]
        public string numero_cuenta { get; set; }
        [DataMember]
        public string observacion { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private CmpProveedor Asignar(DataRow registro)
        {
            CmpProveedor one = new CmpProveedor();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_empresa = registro["id_empresa"].ToString();
            one.nombre = registro["nombre"].ToString();
            one.rif = registro["rif"].ToString();
            one.direccion= registro["direccion"].ToString();
            one.telefono = registro["telefono"].ToString();
            one.email = registro["email"].ToString();
            one.representante = registro["representante"].ToString();
            one.id_banco = registro["id_banco"].ToString();
            one.banco_nombre = registro["banco_nombre"].ToString();
            one.numero_cuenta = registro["numero_cuenta"].ToString();
            one.observacion = registro["observacion"].ToString();

            return one;
        }

        public List<CmpProveedor> GetList(string idEmpresa)
        {
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("compras_proveedores_SEL", parametros);

            List<CmpProveedor> miLista = new List<CmpProveedor>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                CmpProveedor one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public CmpProveedor GetOne(string idEmpresa, string id)
        {
            CmpProveedor one = new CmpProveedor();
            if (id == "0")
            {
                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.id_empresa = idEmpresa;
                one.nombre = "Proveedor Nuevo";
                one.rif = "";
                one.direccion = "";
                one.telefono = "";
                one.email = "";
                one.representante = "";
                one.id_banco = "";
                one.banco_nombre = "";
                one.numero_cuenta = "";
                one.observacion = "";
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

        public string SetOne(CmpProveedor one)
        {
            string procedureName = "";
            string response = "";
            bool res = false;

            //CONFIGURA PARAMETROS
            parametros.id = one.id;
            parametros.order_id = one.order_id;
            parametros.last_update = one.last_update;
            parametros.id_empresa = one.id_empresa;
            parametros.nombre = one.nombre;
            parametros.rif = one.rif;
            parametros.direccion = one.direccion;
            parametros.telefono = one.telefono;
            parametros.email = one.email;
            parametros.representante = one.representante;
            parametros.id_banco = one.id_banco;
            parametros.numero_cuenta = one.numero_cuenta;
            parametros.observacion= one.observacion;

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
                        procedureName = "compras_proveedores_INS";
                    }
                    else
                    {
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        procedureName = "compras_proveedores_UPD";
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
