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
    public class SisUsuarios
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
        public string empresa_nombre { get; set; }
        [DataMember]
        public sbyte id_tipo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string cedula { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string logname { get; set; }
        [DataMember]
        public string pass { get; set; }
        [DataMember]
        public string permisos { get; set; }
        [DataMember]
        public bool es_inactivo { get; set; }
        [DataMember]
        public bool empresa_inactiva { get; set; }
        [DataMember]
        public string numero { get; set; }
        #endregion

        #region METODOS
        DALHandler myHandler = new DALHandler();    //Referencia Clase DALHandler
        private dynamic parametros = new System.Dynamic.ExpandoObject();


        private SisUsuarios Asignar(DataRow registro)
        {
            SisUsuarios one = new SisUsuarios();
            one.id = registro["id"].ToString();
            one.order_id = (int)registro["order_id"];
            one.last_update = (int)registro["last_update"];
            one.id_empresa = registro["id_empresa"].ToString();
            one.nombre = registro["nombre"].ToString();
            one.cedula = registro["cedula"].ToString();
            one.telefono = registro["telefono"].ToString();
            one.email = registro["email"].ToString();
            one.numero= registro["numero"].ToString();
            one.es_inactivo= Convert.ToBoolean((sbyte)registro["es_inactivo"]);
            return one;
        }

        public List<SisUsuarios> GetList(string idEmpresa)
        {
            parametros.id_empresa = idEmpresa;
            DataTable miTabla = myHandler.Consulta("sistema_usuarios_SEL", parametros);

            List<SisUsuarios> miLista = new List<SisUsuarios>();
            foreach (DataRow miRegistro in miTabla.Rows)
            {
                SisUsuarios one = Asignar(miRegistro);
                miLista.Add(one);
            }
            return miLista;
        }
        /*
        public Productos GetOne(string codigo)
        {
            Productos one = new Productos();
            if (codigo == "0")
            {
                one.codigo = "";
                one.id = "0";
                one.id_categoria = "";
                one.categoria_nombre = "";
                one.id_unidad = "";
                one.unidad_nombre = "";
                one.nombre = "Nuevo Producto";
                one.order_id = "0";
                one.precio = 0.00;
            }
            else
            {
                DataTable miTabla = ProductosData.GetOne(codigo);
                if (miTabla.Rows.Count == 0) return null;

                DataRow miRegistro = miTabla.Rows[0];
                one.codigo = miRegistro["codigo"].ToString();
                one.id = miRegistro["id"].ToString();
                one.id_categoria = miRegistro["id_categoria"].ToString();
                one.categoria_nombre = miRegistro["categoria_nombre"].ToString();
                one.id_unidad = miRegistro["id_unidad"].ToString();
                one.unidad_nombre = miRegistro["unidad_nombre"].ToString();
                one.nombre = miRegistro["nombre"].ToString();
                one.order_id = miRegistro["order_id"].ToString();
                one.precio = (double)miRegistro["precio"];
            }

            return one;
        }
        */
        public SisUsuarios Login(string logname, string pass)
        {
            SisUsuarios one = new SisUsuarios();
            parametros.logname = logname;
            parametros.pass = pass;
            DataTable miTabla = myHandler.Consulta("sistema_usuarios_LOGIN", parametros);
            if (miTabla.Rows.Count == 0) return null;

            DataRow miRegistro = miTabla.Rows[0];
            one.id = miRegistro["id"].ToString();
            one.order_id = (int)miRegistro["order_id"];
            one.id_empresa = miRegistro["id_empresa"].ToString();
            one.id_tipo = (sbyte)miRegistro["id_tipo"];
            one.nombre = miRegistro["nombre"].ToString();
            one.cedula = miRegistro["cedula"].ToString();
            one.telefono = miRegistro["telefono"].ToString();
            one.email = miRegistro["email"].ToString();
            one.logname = miRegistro["logname"].ToString();
            one.pass = miRegistro["pass"].ToString();
            one.permisos= miRegistro["permisos"].ToString();
            one.es_inactivo = Convert.ToBoolean((sbyte)miRegistro["es_inactivo"]);
            one.empresa_nombre= miRegistro["empresa_nombre"].ToString();
            one.empresa_inactiva= Convert.ToBoolean((sbyte)miRegistro["empresa_inactiva"]);
            one.numero= miRegistro["numero"].ToString();
            return one;
        }
        #endregion
    }
}
