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
    public class InvOperacion
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
        public int numero { get; set; }
        [DataMember]
        public string nro_control { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public string id_destino { get; set; }
        [DataMember]
        public int id_status { get; set; }
        [DataMember]
        public int id_estado { get; set; }
        [DataMember]
        public string id_usuario { get; set; }
        [DataMember]
        public string usuario_nombre { get; set; }
        [DataMember]
        public string observacion { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private InvOperacion Asignar(DataRow registro)
        {
            InvOperacion one = new InvOperacion();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_empresa = registro["id_empresa"].ToString();
            one.id_tipo_operacion = registro["id_tipo_operacion"].ToString();
            one.numero = (int)registro["numero"];
            one.nro_control = registro["nro_control"].ToString();
            one.fecha = DateTime.Parse(registro["fecha"].ToString());
            one.fecha_registro = DateTime.Parse(registro["fecha_registro"].ToString());
            one.id_destino = registro["id_destino"].ToString();
            one.id_status = (int)registro["id_status"];
            one.id_estado = (int)registro["id_estado"];
            one.id_usuario = registro["id_usuario"].ToString();
            one.usuario_nombre = registro["usuario_nombre"].ToString();
            one.observacion = registro["observacion"].ToString();

            return one;
        }

        public List<InvOperacion> GetList(string idEmpresa, string idTipo)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_tipo = idTipo;
            DataTable miTabla = myHandler.Consulta("inventario_operaciones_SEL", parametros);

            List<InvOperacion> miLista = new List<InvOperacion>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                InvOperacion one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        private int getLastNumber(string idEmpresa, string idTipo)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_tipo = idTipo;

            DataTable miTabla = myHandler.Consulta("inventario_operaciones_LAST", parametros);
            if (miTabla.Rows.Count == 0) return 0;

            DataRow miRegistro = miTabla.Rows[0];
            return Convert.ToInt32(miRegistro["lastnumero"]);

        }

        private List<SisImpuesto> getTasasImpuesto()
        {
            parametros.id = "";

            DataTable miTabla = myHandler.Consulta("sistema_impuestos_SEL", parametros);
            List<SisImpuesto> miLista = new List<SisImpuesto>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                SisImpuesto one = new SisImpuesto();
                one.id = miRegistro["id"].ToString();
                one.valor = (double)miRegistro["valor"];
                miLista.Add(one);
            }
            return miLista;
        }

        private double GetValorImpuesto(List<SisImpuesto> _lista, string id)
        {
            double valor = 0;
            SisImpuesto impuesto = new SisImpuesto();
            impuesto = _lista.Find(x => x.id.Contains(id));
            if (impuesto != null) valor = impuesto.valor;
            return valor;
        }

        public InvOperacion GetOne(string idEmpresa, string idTipo, string id)
        {
            InvOperacion one = new InvOperacion();
            if (id == "0")
            {
                int _lastNumber = getLastNumber(idEmpresa, idTipo) + 1;
                string _lastControl = _lastNumber.ToString("00000000");
                List<SisImpuesto> listaTasas = getTasasImpuesto();

                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.id_empresa = idEmpresa;
                one.id_tipo_operacion = idTipo;
                one.numero = _lastNumber;
                one.nro_control = _lastControl;
                one.fecha = DateTime.Now;
                one.fecha_registro = DateTime.Now;
                one.id_destino = "";
                one.id_status = 0;
                one.id_estado = 0;
                one.id_usuario = "";
                one.usuario_nombre = "";
                one.observacion = "";

            }
            else
            {
                parametros.id_empresa = idEmpresa;
                parametros.id = id;
                DataTable miTabla = myHandler.Consulta("inventario_operaciones_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];
                one = Asignar(miRegistro);
            }
            return one;
        }

        public string SetOne(InvOperacion one, List<InvMovimiento> detail)
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
            parametros.id_destino = one.id_destino;
            parametros.id_status = one.id_status;
            parametros.id_estado = one.id_estado;
            parametros.id_usuario = one.id_usuario;
            //parametros.usuario_nombre = one.usuario_nombre;
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
                        procedureName = "inventario_operaciones_INS";

                    }
                    else
                    {
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        procedureName = "inventario_operaciones_UPD";
                    }
                }


                res = myHandler.Comando(procedureName, parametros);

                if (res)
                {
                    SisSync.SaveSQL(procedureName, parametros);

                    // DETALLE (InvMovimiento) //
                    InvMovimiento srvDetalle = new InvMovimiento();
                    SisOperacion srvOperacion = new SisOperacion();
                    InvProducto srvProducto = new InvProducto();

                    SisOperacion operacion = new SisOperacion();
                    operacion = srvOperacion.GetOne(one.id_tipo_operacion);

                    foreach (InvMovimiento item in detail)
                    {
                        item.id_operacion = parametros.id;
                        string resDetalle = srvDetalle.SetOne(item);
                        // ACTUALIZAR INVENTARIO //
                        string idProd = srvProducto.UpdateExistencia(item.id_producto, operacion.signo_inventario, item.cantidad);
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

        public string NullOne(InvOperacion one, List<InvMovimiento> detail)
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
            parametros.id_destino = one.id_destino;
            parametros.id_status = 2;
            parametros.id_estado = 2;
            parametros.id_usuario = one.id_usuario;
            parametros.usuario_nombre = one.usuario_nombre;
            parametros.observacion = one.observacion;

            try
            {
                DataTable miTabla = myHandler.Consulta("getUUID", null);
                if (miTabla.Rows.Count != 0)
                {
                    DataRow miRegistro = miTabla.Rows[0];
                    parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                    procedureName = "inventario_operaciones_UPD";
                }

                res = myHandler.Comando(procedureName, parametros);

                if (res)
                {
                    SisSync.SaveSQL(procedureName, parametros);

                    // DETALLE (InvMovimiento) //
                    InvMovimiento srvDetalle = new InvMovimiento();
                    SisOperacion srvOperacion = new SisOperacion();
                    InvProducto srvProducto = new InvProducto();

                    SisOperacion operacion = new SisOperacion();
                    operacion = srvOperacion.GetOne(one.id_tipo_operacion);

                    if (operacion.signo_inventario != "N")
                    {
                        foreach (InvMovimiento item in detail)
                        {
                            // ACTUALIZAR INVENTARIO //
                            string _signo = "N";
                            if (operacion.signo_inventario == "+") _signo = "-";
                            if (operacion.signo_inventario == "-") _signo = "+";
                            string idProd = srvProducto.UpdateExistencia(item.id_producto, _signo, item.cantidad);
                        }
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


        #endregion
    }
}
