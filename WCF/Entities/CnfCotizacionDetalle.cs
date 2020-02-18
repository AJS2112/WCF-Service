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
    public class CnfCotizacionDetalle
    {
        #region PROPIEDADES
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public int order_id { get; set; }
        [DataMember]
        public int last_update { get; set; }
        [DataMember]
        public string id_cotizacion { get; set; }
        [DataMember]
        public string id_moneda { get; set; }
        [DataMember]
        public string moneda_nombre { get; set; }
        [DataMember]
        public string moneda_descrip { get; set; }
        [DataMember]
        public double valor_anterior { get; set; }
        [DataMember]
        public double valor { get; set; }
        #endregion
        /*
        #region METODOS
        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        private CnfCotizacionDetalle Asignar(DataRow registro)
        {
            CnfCotizacionDetalle one = new CnfCotizacionDetalle();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_cotizacion = registro["id_cotizacion"].ToString();
            one.id_moneda = registro["id_moneda"].ToString();
            one.moneda_nombre = registro["moneda_nombre"].ToString();
            one.moneda_descrip = registro["moneda_descrip"].ToString();
            one.valor_anterior = (double)registro["valor_anterior"];
            one.valor = (double)registro["valor"];

            return one;
        }


        public List<CnfCotizacionDetalle> GetList(string idCotizacion)
        {
            parametros.id_cotizacion = idCotizacion;
            DataTable miTabla = myHandler.Consulta("listas_cotizaciones_detail_SEL", parametros);

            List<CnfCotizacionDetalle> miLista = new List<CnfCotizacionDetalle>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                CnfCotizacionDetalle one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }

        

        public bool SetDetail(string idCotizacion, List<CnfCotizacionDetalle> lista)
        {
            string procedureName = "";
            bool res = false;

            foreach (var item in lista)
            {
                //CONFIGURA PARAMETROS
                parametros.id = item.id;
                parametros.order_id = item.order_id;
                parametros.last_update = item.last_update;
                parametros.id_cotizacion = idCotizacion;
                parametros.id_moneda = item.id_moneda;
                parametros.valor_anterior = item.valor_anterior;
                parametros.valor = item.valor;

                try
                {
                    //TRANSACCION
                    DataTable miTabla = myHandler.Consulta("getUUID", null);
                    if (miTabla.Rows.Count != 0)
                    {
                        DataRow miRegistro = miTabla.Rows[0];
                        if (item.id == "0")
                        {
                            parametros.id = miRegistro["id"].ToString();
                            parametros.order_id = Convert.ToInt32(miRegistro["order_id"]);
                            parametros.last_update = Convert.ToInt32(miRegistro["order_id"]);
                            procedureName = "listas_cotizaciones_detail_INS";
                        }
                    }


                    res = myHandler.Comando(procedureName, parametros);

                    if (res)
                    {
                        SisSync.SaveSQL(procedureName, parametros);
                        res = true;
                    }
                    else
                    {
                        res=false;
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
    */
    }
}
