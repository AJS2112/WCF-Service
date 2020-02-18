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
    public class SisImpuesto
    {
        #region PROPIEDADES
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public int order_id { get; set; }
        [DataMember]
        public int last_update { get; set; }
        [DataMember]
        public string id_tipo { get; set; }
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string valor_display { get; set; }
        [DataMember]
        public double valor { get; set; }
        #endregion

        #region METODOS
        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();

        public List<SisImpuesto> GetList(string id)
        {
            parametros.id = id;
            DataTable miTabla = myHandler.Consulta("sistema_impuestos_SEL", parametros);

            List<SisImpuesto> miLista = new List<SisImpuesto>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                SisImpuesto one = new SisImpuesto();
                one.id = miRegistro["id"].ToString();
                one.order_id = (int)miRegistro["order_id"];
                one.last_update = (int)miRegistro["last_update"];
                one.id_tipo = miRegistro["id_tipo"].ToString();
                one.codigo = miRegistro["codigo"].ToString();
                one.nombre = miRegistro["nombre"].ToString();
                one.valor_display= miRegistro["valor_display"].ToString();
                one.valor= (double)miRegistro["valor"];
                miLista.Add(one);
            }
            return miLista;
        }
        
        #endregion
    }
}
