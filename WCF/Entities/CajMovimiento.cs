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
    public class CajMovimiento
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
        public DateTime fecha { get; set; }
        [DataMember]
        public string id_tipo_operacion { get; set; }
        [DataMember]
        public string id_operacion { get; set; }
        [DataMember]
        public double monto { get; set; }
        [DataMember]
        public double monto_moneda { get; set; }
        [DataMember]
        public string id_moneda { get; set; }
        [DataMember]
        public string moneda_nombre { get; set; }
        [DataMember]
        public string moneda_descrip { get; set; }
        [DataMember]
        public double factor { get; set; }
        [DataMember]
        public string id_instrumento { get; set; }
        [DataMember]
        public string instrumento_nombre { get; set; }
        [DataMember]
        public string id_cuenta { get; set; }
        [DataMember]
        public string cuenta_numero { get; set; }
        [DataMember]
        public string cuenta_banco { get; set; }
        [DataMember]
        public string id_banco { get; set; }
        [DataMember]
        public string banco_nombre { get; set; }
        [DataMember]
        public string numero_operacion { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private CajMovimiento Asignar(DataRow registro)
        {
            CajMovimiento one = new CajMovimiento();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_empresa = registro["id_empresa"].ToString();
            one.fecha= DateTime.Parse(registro["fecha"].ToString());
            one.id_tipo_operacion = registro["id_tipo_operacion"].ToString();
            one.id_operacion = registro["id_operacion"].ToString();
            one.monto = Convert.ToDouble(registro["monto"]);
            one.monto_moneda = Convert.ToDouble(registro["monto_moneda"]);
            one.id_moneda = registro["id_moneda"].ToString();
            one.moneda_nombre = registro["moneda_nombre"].ToString();
            one.moneda_descrip = registro["moneda_descrip"].ToString();
            one.factor= Convert.ToDouble(registro["factor"]);
            one.id_instrumento= registro["id_instrumento"].ToString();
            one.instrumento_nombre = registro["instrumento_nombre"].ToString();
            one.id_cuenta = registro["id_cuenta"].ToString();
            one.cuenta_numero= registro["cuenta_numero"].ToString();
            one.cuenta_banco = registro["cuenta_banco"].ToString();
            one.id_banco = registro["id_banco"].ToString();
            one.banco_nombre = registro["banco_nombre"].ToString();
            one.numero_operacion = registro["numero_operacion"].ToString();
            return one;
        }

        public bool Delete(string idOperacion)
        {
            try
            {
                parametros.id_operacion = idOperacion;
                DataTable miTabla = myHandler.Consulta("caja_movimientos_DEL", parametros);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<CajMovimiento> GetList(string idOperacion)
        {
            parametros.id_operacion = idOperacion;
            DataTable miTabla = myHandler.Consulta("caja_movimientos_SEL", parametros);

            List<CajMovimiento> miLista = new List<CajMovimiento>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                CajMovimiento one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public string SetOne(CajMovimiento one)
        {
            string procedureName = "";
            string response = "";
            bool res = false;

            //CONFIGURA PARAMETROS
            parametros.id = one.id;
            parametros.order_id = one.order_id;
            parametros.last_update = one.last_update;
            parametros.id_empresa = one.id_empresa;
            parametros.fecha = one.fecha;
            parametros.id_tipo_operacion = one.id_tipo_operacion;
            parametros.id_operacion = one.id_operacion;
            parametros.monto = one.monto;
            parametros.id_instrumento = one.id_instrumento;
            parametros.id_cuenta = one.id_cuenta;
            parametros.id_banco = one.id_banco;
            parametros.numero_operacion = one.numero_operacion;
            parametros.id_moneda = one.id_moneda;
            parametros.factor = one.factor;

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
                        procedureName = "caja_movimientos_INS";
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
