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
    public class CnfCotizacion
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
        public int numero { get; set; }
        [DataMember]
        public string nro_control { get; set; }
        [DataMember]
        public DateTime fecha_registro { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public string observacion { get; set; }
        #endregion

        #region METODOS
        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();
        
        private CnfCotizacion Asignar(DataRow registro)
        {
            CnfCotizacion one = new CnfCotizacion();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_empresa = registro["id_empresa"].ToString();
            one.numero = (int)registro["numero"];
            one.nro_control = registro["nro_control"].ToString();
            one.fecha = Convert.ToDateTime(registro["fecha"]);
            one.fecha_registro = Convert.ToDateTime(registro["fecha_registro"]);
            one.observacion = registro["observacion"].ToString();

            return one;
        }

        private CnfCotizacionDetalle AsignarDetalle(DataRow registro)
        {
            CnfCotizacionDetalle one = new CnfCotizacionDetalle();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_cotizacion = registro["id_cotizacion"].ToString();
            one.id_moneda = registro["id_moneda"].ToString();
            one.moneda_nombre = registro["moneda_nombre"].ToString();
            one.moneda_descrip = registro["moneda_descrip"].ToString();
            one.valor_anterior = Convert.ToDouble(registro["valor_anterior"]);
            one.valor = Convert.ToDouble(registro["valor"]);

            return one;
        }

        public List<CnfCotizacionDetalle> GetLast(string idEmpresa)
        {
            /*List<CnfCotizacionDetalle> list = new List<CnfCotizacionDetalle>();
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("listas_cotizaciones_LAST", parametros);
            if (miTabla.Rows.Count == 0) return null;

            DataRow miRegistro = miTabla.Rows[0];
            one = Asignar(miRegistro);

            return one;*/


            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("listas_cotizaciones_LAST", parametros);

            List<CnfCotizacionDetalle> miLista = new List<CnfCotizacionDetalle>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                CnfCotizacionDetalle one = AsignarDetalle(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }
        private int GetLastN(string idEmpresa)
        {
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("listas_cotizaciones_LASTN", parametros);
            if (miTabla.Rows.Count == 0) return 0;

            DataRow miRegistro = miTabla.Rows[0];
                return (int)miRegistro["lastnumero"];
        }

        public List<CnfCotizacion> GetList(string idEmpresa)
        {
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("listas_cotizaciones_SEL", parametros);

            List<CnfCotizacion> miLista = new List<CnfCotizacion>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                CnfCotizacion one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<CnfCotizacionDetalle> GetListDetail(string idCotizacion)
        {
            parametros.id_cotizacion = idCotizacion;
            DataTable miTabla = myHandler.Consulta("listas_cotizaciones_detail_SEL", parametros);

            List<CnfCotizacionDetalle> miLista = new List<CnfCotizacionDetalle>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                CnfCotizacionDetalle one = AsignarDetalle(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        public CnfCotizacion GetOne(string idEmpresa, string id)
        {
            int _lastNumber = 1;
            string _lastControl = _lastNumber.ToString("00000000");

            int _ultima = GetLastN(idEmpresa);
            _lastNumber = _ultima + 1;
            _lastControl = _lastNumber.ToString("00000000");
            CnfCotizacion one = new CnfCotizacion();
            if (id == "0")
            {
                one.id = "0";
                one.order_id = 0;
                one.last_update = 0;
                one.id_empresa = idEmpresa;
                one.numero = _lastNumber;
                one.nro_control= _lastControl;
                one.fecha = DateTime.Now;
                one.fecha_registro = DateTime.Now;
                one.observacion ="";
            }
            else
            {
                parametros.id_empresa = idEmpresa;
                parametros.id = id;
                DataTable miTabla = myHandler.Consulta("listas_cotizaciones_ONE", parametros);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];
                one = Asignar(miRegistro);
            }
            return one;
        }

        public string SetOne(CnfCotizacion one, List<CnfCotizacionDetalle> detail)
        {
            string procedureName = "";
            string response = "";
            bool res = false;

            //CONFIGURA PARAMETROS
            parametros.id = one.id;
            parametros.order_id = one.order_id;
            parametros.last_update = one.last_update;
            parametros.id_empresa = one.id_empresa;
            parametros.numero = one.numero;
            parametros.nro_control = one.nro_control;
            parametros.fecha = one.fecha;
            //parametros.fecha_registro = one.fecha_registro;
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
                        procedureName = "listas_cotizaciones_INS";
                    }
                }
                
                res = myHandler.Comando(procedureName, parametros);

                if (res)
                {
                    SisSync.SaveSQL(procedureName, parametros);
                    //SET DETAIL //
                    if (SetDetail(parametros.id, detail))
                    {
                        response = parametros.id;
                    } else
                    {
                        response = "";
                    }
                    
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

        private bool SetDetail(string idCotizacion, List<CnfCotizacionDetalle> lista)
        {
            string procedureName = "";
            bool res = false;
            dynamic _parametrosDetalle = new System.Dynamic.ExpandoObject();

            //ADD DOLAR
            lista.Insert(0, new CnfCotizacionDetalle
            {
                id = "0",
                order_id = 0,
                last_update = 0,
                id_cotizacion = "0",
                id_moneda = "11E8F819279E29CC9E9100270E383B06",
                valor_anterior = 1,
                valor = 1
            });
            foreach (var item in lista)
            {
                //CONFIGURA PARAMETROS
                _parametrosDetalle.id = item.id;
                _parametrosDetalle.order_id = item.order_id;
                _parametrosDetalle.last_update = item.last_update;
                _parametrosDetalle.id_cotizacion = idCotizacion;
                _parametrosDetalle.id_moneda = item.id_moneda;
                _parametrosDetalle.valor_anterior = item.valor_anterior;
                _parametrosDetalle.valor = item.valor;

                try
                {
                    //TRANSACCION
                    DataTable miTabla = myHandler.Consulta("getUUID", null);
                    if (miTabla.Rows.Count != 0)
                    {
                        DataRow miRegistro = miTabla.Rows[0];
                        if (item.id == "0")
                        {
                            _parametrosDetalle.id = miRegistro["id"].ToString();
                            _parametrosDetalle.order_id = Convert.ToInt32(miRegistro["order_id"]);
                            _parametrosDetalle.last_update = Convert.ToInt32(miRegistro["order_id"]);
                            procedureName = "listas_cotizaciones_detail_INS";
                        }
                    }

                    res = myHandler.Comando(procedureName, _parametrosDetalle);

                    if (res)
                    {
                        SisSync.SaveSQL(procedureName, _parametrosDetalle);
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return res;

        }

        #endregion
    }
}
