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
    public class VntCliente
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
        public string rif { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public double limite_credito { get; set; }
        [DataMember]
        public string observacion { get; set; }

        [DataMember]
        public double total { get; set; }
        [DataMember]
        public double abonos { get; set; }
        [DataMember]
        public double deuda { get; set; }
        [DataMember]
        public double total_moneda { get; set; }
        [DataMember]
        public double abonos_moneda { get; set; }
        [DataMember]
        public double deuda_moneda { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private VntCliente Asignar(DataRow registro)
        {
            VntCliente one = new VntCliente();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_empresa = registro["id_empresa"].ToString();
            one.nombre = registro["nombre"].ToString();
            one.rif = registro["rif"].ToString();
            one.direccion = registro["direccion"].ToString();
            one.telefono = registro["telefono"].ToString();
            one.email = registro["email"].ToString();
            one.limite_credito = (double)registro["limite_credito"];
            one.observacion = registro["observacion"].ToString();

            one.total = Convert.ToDouble(registro["total"]);
            one.abonos= Convert.ToDouble(registro["abonos"]);
            one.deuda= Convert.ToDouble(registro["deuda"]);

            one.total_moneda= Convert.ToDouble(registro["total_moneda"]);
            one.abonos_moneda = Convert.ToDouble(registro["abonos_moneda"]);
            one.deuda_moneda = Convert.ToDouble(registro["deuda_moneda"]);
            return one;
        }

        public List<VntCliente> GetList(string idEmpresa)
        {
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("ventas_clientes_SEL", parametros);

            List<VntCliente> miLista = new List<VntCliente>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                VntCliente one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public VntCliente GetOne(string idEmpresa, string id)
        {
            VntCliente one = new VntCliente();
            if (id == "0")
            {
                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.id_empresa = idEmpresa;
                one.nombre = "Cliente Nuevo";
                one.rif = "";
                one.direccion = "";
                one.telefono = "";
                one.email = "";
                one.limite_credito = 0;
                one.observacion = "";

                one.total = 0;
                one.abonos = 0;
                one.deuda = 0;
                one.total_moneda = 0;
                one.abonos_moneda = 0;
                one.deuda_moneda = 0;
            }
            else
            {
                parametros.id_empresa = idEmpresa;
                parametros.id = id;
                DataTable miTabla = myHandler.Consulta("ventas_clientes_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];
                one = Asignar(miRegistro);
            }
            return one;
        }

        public string SetOne(VntCliente one)
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
            parametros.limite_credito= one.limite_credito;
            parametros.observacion = one.observacion;

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
                        procedureName = "ventas_clientes_INS";
                    }
                    else
                    {
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        procedureName = "ventas_clientes_UPD";
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
