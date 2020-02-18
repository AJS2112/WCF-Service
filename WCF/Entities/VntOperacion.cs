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
    public class VntOperacion
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
        public string id_cliente { get; set; }
        [DataMember]
        public string cliente_nombre { get; set; }
        [DataMember]
        public string cliente_rif { get; set; }
        [DataMember]
        public string id_tipo_documento { get; set; }
        [DataMember]
        public string tipo_documento_nombre { get; set; }
        [DataMember]
        public string nro_control_documento { get; set; }
        [DataMember]
        public string nro_documento { get; set; }
        [DataMember]
        public DateTime fecha_documento { get; set; }
        [DataMember]
        public string nro_factura_afectada { get; set; }
        [DataMember]
        public string id_doc_origen { get; set; }
        [DataMember]
        public string id_cotizacion { get; set; }
        [DataMember]
        public double monto_exento { get; set; }
        [DataMember]
        public double base_imponible_tg { get; set; }
        [DataMember]
        public double base_imponible_tr { get; set; }
        [DataMember]
        public double base_imponible_ta { get; set; }
        [DataMember]
        public double pct_alicuota_tg { get; set; }
        [DataMember]
        public double pct_alicuota_tr { get; set; }
        [DataMember]
        public double pct_alicuota_ta { get; set; }
        [DataMember]
        public double monto_iva_tg { get; set; }
        [DataMember]
        public double monto_iva_tr { get; set; }
        [DataMember]
        public double monto_iva_ta { get; set; }
        [DataMember]
        public double total { get; set; }

        // MONEDA //
        [DataMember]
        public double monto_exento_moneda { get; set; }
        [DataMember]
        public double base_imponible_tg_moneda { get; set; }
        [DataMember]
        public double base_imponible_tr_moneda { get; set; }
        [DataMember]
        public double base_imponible_ta_moneda { get; set; }
        [DataMember]
        public double monto_iva_tg_moneda { get; set; }
        [DataMember]
        public double monto_iva_tr_moneda { get; set; }
        [DataMember]
        public double monto_iva_ta_moneda { get; set; }
        [DataMember]
        public double total_moneda { get; set; }

        [DataMember]
        public double pct_descuento { get; set; }
        [DataMember]
        public double pct_adicional { get; set; }
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


        [DataMember]
        public double abono { get; set; }
        [DataMember]
        public double deuda { get; set; }
        [DataMember]
        public double abono_moneda { get; set; }
        [DataMember]
        public double deuda_moneda { get; set; }
        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private VntOperacion Asignar(DataRow registro)
        {
            VntOperacion one = new VntOperacion();
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
            one.id_cliente = registro["id_cliente"].ToString();
            one.cliente_nombre = registro["cliente_nombre"].ToString();
            one.cliente_rif = registro["cliente_rif"].ToString();

            one.id_tipo_documento = registro["id_tipo_documento"].ToString();
            one.tipo_documento_nombre = registro["tipo_documento_nombre"].ToString();
            one.nro_control_documento = registro["nro_control_documento"].ToString();
            one.nro_documento = registro["nro_documento"].ToString();
            one.fecha_documento = DateTime.Parse(registro["fecha_documento"].ToString());
            one.nro_factura_afectada = registro["nro_factura_afectada"].ToString();
            one.id_doc_origen = registro["id_doc_origen"].ToString();
            one.id_cotizacion = registro["id_cotizacion"].ToString();

            one.monto_exento = Convert.ToDouble(registro["monto_exento"]);
            one.base_imponible_tg = Convert.ToDouble(registro["base_imponible_tg"]);
            one.base_imponible_tr = Convert.ToDouble(registro["base_imponible_tr"]);
            one.base_imponible_ta = Convert.ToDouble(registro["base_imponible_ta"]);
            one.pct_alicuota_tg = Convert.ToDouble(registro["pct_alicuota_tg"]);
            one.pct_alicuota_tr = Convert.ToDouble(registro["pct_alicuota_tr"]);
            one.pct_alicuota_ta = Convert.ToDouble(registro["pct_alicuota_ta"]);
            one.monto_iva_tg = Convert.ToDouble(registro["monto_iva_tg"]);
            one.monto_iva_tr = Convert.ToDouble(registro["monto_iva_tr"]);
            one.monto_iva_ta = Convert.ToDouble(registro["monto_iva_ta"]);
            one.total = Convert.ToDouble(registro["total"]);

            one.monto_exento_moneda = Convert.ToDouble(registro["monto_exento_moneda"]);
            one.base_imponible_tg_moneda = Convert.ToDouble(registro["base_imponible_tg_moneda"]);
            one.base_imponible_tr_moneda = Convert.ToDouble(registro["base_imponible_tr_moneda"]);
            one.base_imponible_ta_moneda = Convert.ToDouble(registro["base_imponible_ta_moneda"]);
            one.monto_iva_tg_moneda = Convert.ToDouble(registro["monto_iva_tg_moneda"]);
            one.monto_iva_tr_moneda = Convert.ToDouble(registro["monto_iva_tr_moneda"]);
            one.monto_iva_ta_moneda = Convert.ToDouble(registro["monto_iva_ta_moneda"]);
            one.total_moneda = Convert.ToDouble(registro["total_moneda"]);

            one.pct_descuento = Convert.ToDouble(registro["pct_descuento"]);
            one.pct_adicional = Convert.ToDouble(registro["pct_adicional"]);
            one.id_status = (int)registro["id_status"];
            one.id_estado = (int)registro["id_estado"];
            one.id_usuario = registro["id_usuario"].ToString();
            one.usuario_nombre = registro["usuario_nombre"].ToString();
            one.observacion = registro["observacion"].ToString();

            one.abono = Convert.ToDouble(registro["abonos"]);
            one.deuda= Convert.ToDouble(registro["deuda"]);
            one.abono_moneda = Convert.ToDouble(registro["abonos_moneda"]);
            one.deuda_moneda = Convert.ToDouble(registro["deuda_moneda"]);
            return one;
        }

        public List<VntOperacion> GetDeudasCliente(string idCliente)
        {
            parametros.id_cliente = idCliente;
            DataTable miTabla = myHandler.Consulta("ventas_clientes_DEUDAS", parametros);

            List<VntOperacion> miLista = new List<VntOperacion>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                VntOperacion one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<VntOperacion> GetList(string idEmpresa, string idTipo)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_tipo = idTipo;
            DataTable miTabla = myHandler.Consulta("ventas_operaciones_SEL", parametros);

            List<VntOperacion> miLista = new List<VntOperacion>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                VntOperacion one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        private int getLastNumber(string idEmpresa, string idTipo)
        {
            parametros.id_empresa = idEmpresa;
            parametros.id_tipo = idTipo;

            DataTable miTabla = myHandler.Consulta("ventas_operaciones_LAST", parametros);
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

        public VntOperacion GetOne(string idEmpresa, string idTipo, string id)
        {
            VntOperacion one = new VntOperacion();
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
                one.id_cliente = "";
                one.cliente_nombre = "";
                one.cliente_rif = "";

                one.id_tipo_documento = "";
                one.tipo_documento_nombre = "";
                one.nro_control_documento = "";
                one.nro_documento = "";
                one.fecha_documento = DateTime.Now;
                one.nro_factura_afectada = "";
                one.id_doc_origen = "";
                one.id_cotizacion = "";

                one.monto_exento = 0;
                one.base_imponible_tg = 0;
                one.base_imponible_tr = 0;
                one.base_imponible_ta = 0;
                one.pct_alicuota_tg = GetValorImpuesto(listaTasas, "11E7E1D6570F9A40AC8A00E04C6F7E24");
                one.pct_alicuota_tr = GetValorImpuesto(listaTasas, "11E8F23EEF10FE9E8FF600270E383B06");
                one.pct_alicuota_ta = GetValorImpuesto(listaTasas, "11E8F23EF76C98758FF600270E383B06");
                one.monto_iva_tg = 0;
                one.monto_iva_tr = 0;
                one.monto_iva_ta = 0;
                one.total = 0;

                one.monto_exento_moneda = 0;
                one.base_imponible_tg_moneda = 0;
                one.base_imponible_tr_moneda = 0;
                one.base_imponible_ta_moneda = 0;
                one.monto_iva_tg_moneda = 0;
                one.monto_iva_tr_moneda = 0;
                one.monto_iva_ta_moneda = 0;
                one.total_moneda = 0;

                one.pct_descuento = 0;
                one.pct_adicional = 0;
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
                DataTable miTabla = myHandler.Consulta("ventas_operaciones_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];
                one = Asignar(miRegistro);
            }
            return one;
        }

        public string SetAbono(VntOperacion one, List<CajMovimiento> pago)
        {
            string response = "";

            try
            {
                // PAGO (CajMovimiento) //
                CajMovimiento srvPago = new CajMovimiento();
                foreach (CajMovimiento myItem in pago)
                {
                    myItem.id_operacion = one.id;
                    myItem.id_tipo_operacion = one.id_tipo_operacion;
                    myItem.fecha = one.fecha;
                    string resPago = srvPago.SetOne(myItem);
                    response = one.id;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string SetOne(VntOperacion one, List<InvMovimiento> detail, List<CajMovimiento> pago)
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
            parametros.id_cliente = one.id_cliente;
            parametros.id_tipo_documento = one.id_tipo_documento;

            parametros.nro_control_documento = one.nro_control_documento;
            parametros.nro_documento = one.nro_documento;
            parametros.fecha_documento = one.fecha_documento;
            parametros.nro_factura_afectada = one.nro_factura_afectada;
            parametros.id_doc_origen = one.id_doc_origen;
            parametros.id_cotizacion = one.id_cotizacion;

            parametros.monto_exento = one.monto_exento;
            parametros.base_imponible_tg = one.base_imponible_tg;
            parametros.pct_alicuota_tg = one.pct_alicuota_tg;
            parametros.base_imponible_tr = one.base_imponible_tr;
            parametros.pct_alicuota_tr = one.pct_alicuota_tr;
            parametros.base_imponible_ta = one.base_imponible_ta;
            parametros.pct_alicuota_ta = one.pct_alicuota_ta;

            //parametros.total = one.total;
            parametros.pct_descuento = one.pct_descuento;
            parametros.pct_adicional = one.pct_adicional;
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
                        int _lastNumber = getLastNumber(parametros.id_empresa, parametros.id_tipo_operacion) + 1;
                        string _lastControl = _lastNumber.ToString("00000000");

                        parametros.id = miRegistro["id"].ToString();
                        parametros.order_id = Convert.ToInt32(miRegistro["order_id"]);
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        parametros.numero = _lastNumber;
                        parametros.nro_control = _lastControl;
                        parametros.id_status = 1;
                        parametros.id_estado = 1;
                        procedureName = "ventas_operaciones_INS";

                    }
                    else
                    {
                        parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                        procedureName = "ventas_operaciones_UPD";
                    }
                }


                res = myHandler.Comando(procedureName, parametros);

                if (res)
                {
                    SisSync.SaveSQL(procedureName, parametros);

                    SisOperacion srvOperacion = new SisOperacion();
                    SisOperacion operacion = new SisOperacion();
                    operacion = srvOperacion.GetOne(one.id_tipo_operacion);

                    // DETALLE (InvMovimiento) //
                    InvMovimiento srvDetalle = new InvMovimiento();
                    InvProducto srvProducto = new InvProducto();
                    foreach (InvMovimiento item in detail)
                    {
                        item.id_operacion = parametros.id;
                        string resDetalle = srvDetalle.SetOne(item);
                        // ACTUALIZAR INVENTARIO //
                        string idProd = srvProducto.UpdateExistencia(item.id_producto, operacion.signo_inventario, item.cantidad);
                    }

                    // PAGO (CajMovimiento) //
                    CajMovimiento srvPago = new CajMovimiento();
                    foreach (CajMovimiento myItem in pago)
                    {
                        myItem.id_operacion = parametros.id;
                        myItem.id_tipo_operacion = one.id_tipo_operacion;
                        myItem.fecha = one.fecha;
                        string resPago = srvPago.SetOne(myItem);
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

        public string NullOne(VntOperacion one, List<InvMovimiento> detail)
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
            parametros.id_cliente = one.id_cliente;
            parametros.id_tipo_documento = one.id_tipo_documento;

            parametros.nro_control_documento = one.nro_control_documento;
            parametros.nro_documento = one.nro_documento;
            parametros.fecha_documento = one.fecha_documento;
            parametros.nro_factura_afectada = one.nro_factura_afectada;
            parametros.id_doc_origen = one.id_doc_origen;
            parametros.id_cotizacion = one.id_cotizacion;

            parametros.monto_exento = one.monto_exento;
            parametros.base_imponible_tg = one.base_imponible_tg;
            parametros.base_imponible_tr = one.base_imponible_tr;
            parametros.base_imponible_ta = one.base_imponible_ta;
            parametros.pct_alicuota_tg = one.pct_alicuota_tg;
            parametros.pct_alicuota_tr = one.pct_alicuota_tr;
            parametros.pct_alicuota_ta = one.pct_alicuota_ta;
            parametros.total = one.total;
            parametros.pct_descuento = one.pct_descuento;
            parametros.pct_adicional = one.pct_adicional;
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
                    procedureName = "ventas_operaciones_UPD";
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
