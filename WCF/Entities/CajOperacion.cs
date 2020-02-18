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
    public class CajOperacion
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
        public string tipo_operacion_nombre { get; set; }
        [DataMember]
        public int numero { get; set; }
        [DataMember]
        public string nro_control { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public double monto { get; set; }
        [DataMember]
        public double monto_moneda { get; set; }
        [DataMember]
        public string id_cotizacion { get; set; }
        [DataMember]
        public int id_status { get; set; }
        [DataMember]
        public int id_estado { get; set; }
        [DataMember]
        public string id_usuario { get; set; }
        [DataMember]
        public string usuario_nombre { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private CajOperacion Asignar(DataRow registro)
        {
            CajOperacion one = new CajOperacion();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_empresa = registro["id_empresa"].ToString();
            one.id_tipo_operacion = registro["id_tipo_operacion"].ToString();
            one.tipo_operacion_nombre = registro["tipo_operacion_nombre"].ToString();
            one.numero = (int)registro["numero"];
            one.nro_control = registro["nro_control"].ToString();
            one.fecha = DateTime.Parse(registro["fecha"].ToString());
            one.fecha_registro = DateTime.Parse(registro["fecha_registro"].ToString());
            one.descripcion = registro["descripcion"].ToString();
            one.monto= Convert.ToDouble(registro["monto"]);
            one.monto_moneda = Convert.ToDouble(registro["monto_moneda"]);
            one.id_cotizacion= registro["id_cotizacion"].ToString();

            one.id_status = (int)registro["id_status"];
            one.id_estado = (int)registro["id_estado"];
            one.id_usuario = registro["id_usuario"].ToString();
            one.usuario_nombre = registro["usuario_nombre"].ToString();

            return one;
        }

        public List<CajOperacion> GetList(string idEmpresa, string idTipo)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_tipo = idTipo;
            DataTable miTabla = myHandler.Consulta("caja_operaciones_SEL", parametros);

            List<CajOperacion> miLista = new List<CajOperacion>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                CajOperacion one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        private int getLastNumber(string idEmpresa, string idTipo)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_tipo = idTipo;

            DataTable miTabla = myHandler.Consulta("caja_operaciones_LAST", parametros);
            if (miTabla.Rows.Count == 0) return 0;

            DataRow miRegistro = miTabla.Rows[0];
            return Convert.ToInt32(miRegistro["lastnumero"]);

        }


        public CajOperacion GetOne(string idEmpresa, string idTipo, string id)
        {
            CajOperacion one = new CajOperacion();
            if (id == "0")
            {
                int _lastNumber = getLastNumber(idEmpresa, idTipo) + 1;
                string _lastControl = _lastNumber.ToString("00000000");

                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.id_empresa = idEmpresa;
                one.id_tipo_operacion = idTipo;
                one.tipo_operacion_nombre = "";
                one.numero = _lastNumber;
                one.nro_control = _lastControl;
                one.fecha = DateTime.Now;
                one.fecha_registro = DateTime.Now;
                one.descripcion = "";
                one.monto= 0;
                one.monto_moneda= 0;
                one.id_cotizacion= "";
                one.id_status = 0;
                one.id_estado = 0;
                one.id_usuario = "";
                one.usuario_nombre = "";
            }
            else
            {
                parametros.id_empresa = idEmpresa;
                parametros.id = id;
                DataTable miTabla = myHandler.Consulta("caja_operaciones_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];
                one = Asignar(miRegistro);
            }
            return one;
        }

        public string SetOne(CajOperacion one, List<CajMovimiento> detail)
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
            parametros.numero = one.numero;
            parametros.nro_control = one.nro_control;
            parametros.fecha = one.fecha;
            parametros.fecha_registro = one.fecha_registro;
            parametros.descripcion = one.descripcion;
            parametros.monto = one.monto;
            parametros.id_cotizacion = one.id_cotizacion;
            parametros.id_status = one.id_status;
            parametros.id_estado = one.id_estado;
            parametros.id_usuario = one.id_usuario;

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
                        procedureName = "caja_operaciones_INS";

                    }
                    else
                    {
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        procedureName = "caja_operaciones_UPD";
                    }
                }


                res = myHandler.Comando(procedureName, parametros);

                if (res)
                {
                    SisSync.SaveSQL(procedureName, parametros);

                    // DETALLE (CajMovimiento) //
                    CajMovimiento srvDetalle = new CajMovimiento();
                    SisOperacion srvOperacion = new SisOperacion();

                    SisOperacion operacion = new SisOperacion();
                    operacion = srvOperacion.GetOne(one.id_tipo_operacion);

                    foreach (CajMovimiento item in detail)
                    {
                        item.id_operacion = parametros.id;
                        item.id_tipo_operacion = one.id_tipo_operacion;
                        item.fecha = one.fecha;
                        string resDetalle = srvDetalle.SetOne(item);
                    }

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

        public string NullOne(CajOperacion one)
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
            parametros.numero = one.numero;
            parametros.nro_control = one.nro_control;
            parametros.fecha = one.fecha;
            parametros.fecha_registro = one.fecha_registro;
            parametros.descripcion = one.descripcion;
            parametros.monto = one.monto;
            parametros.id_cotizacion = one.id_cotizacion;

            parametros.id_status = 2;
            parametros.id_estado = 2;
            parametros.id_usuario = one.id_usuario;
            parametros.usuario_nombre = one.usuario_nombre;

            try
            {
                DataTable miTabla = myHandler.Consulta("getUUID", null);
                if (miTabla.Rows.Count != 0)
                {
                    DataRow miRegistro = miTabla.Rows[0];
                    parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                    procedureName = "caja_operaciones_UPD";
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
