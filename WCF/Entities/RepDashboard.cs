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
    public class RepDashboard
    {
        #region PROPIEDADES
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public double cantidad { get; set; }
        [DataMember]
        public double entrada { get; set; }
        [DataMember]
        public double salida { get; set; }
        [DataMember]
        public double total { get; set; }

        [DataMember]
        public double entrada_moneda { get; set; }
        [DataMember]
        public double salida_moneda { get; set; }
        [DataMember]
        public double total_moneda { get; set; }

        #endregion

        #region METODOS

        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        public List<RepDashboard> GetResumenCaja(string idEmpresa, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reporte_dashboard_caja", parametros);

            List<RepDashboard> miLista = new List<RepDashboard>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepDashboard one = new RepDashboard();

                one.nombre = miRegistro["instrumento"].ToString();
                one.cantidad= Convert.ToDouble(miRegistro["cuenta"]);
                one.entrada= Convert.ToDouble(miRegistro["ent"]);
                one.salida= Convert.ToDouble(miRegistro["sal"]);
                one.total = Convert.ToDouble(miRegistro["total"]);
                one.entrada_moneda = Convert.ToDouble(miRegistro["ent"]);
                one.salida_moneda = Convert.ToDouble(miRegistro["sal"]);
                one.total_moneda = Convert.ToDouble(miRegistro["total"]);
                miLista.Add(one);
            }
            return miLista;
        }

        public List<RepDashboard> GetResumenGeneral(string idEmpresa, string desde, string hasta)
        {
            parametros.id_empresa = idEmpresa;
            parametros.desde = desde;
            parametros.hasta = hasta;

            DataTable miTabla = myHandler.Consulta("reporte_dashboard_resumen", parametros);

            List<RepDashboard> miLista = new List<RepDashboard>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                RepDashboard one = new RepDashboard();

                one.nombre = miRegistro["item"].ToString();
                one.cantidad = Convert.ToDouble(miRegistro["cantidad"]);
                one.entrada = 0;
                one.salida = 0;
                one.total = Convert.ToDouble(miRegistro["total"]);
                one.entrada_moneda = 0;
                one.salida_moneda = 0;
                one.total_moneda = Convert.ToDouble(miRegistro["total"]);
                miLista.Add(one);
            }
            return miLista;
        }

        #endregion
    }
}
