using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALHandler
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
        private static MySqlConnection conn = new MySqlConnection(connectionString);


        //Método Abrir Conexión
        void abrir_conexion()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        //Método Cerrar Conexión
        void cerrar_conexion()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        //Método para ejecutar SP (CRUD)

        public bool Comando(string NombreSP, dynamic obj)
        {
            bool response = false;
            MySqlCommand cmd;
            try
            {
                abrir_conexion();
                cmd = new MySqlCommand(NombreSP, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (obj != null)
                {
                    IDictionary<string, object> parametros = obj;
                    foreach (var property in parametros.Keys)
                    {
                        cmd.Parameters.AddWithValue("_"+property, parametros[property]);
                    }
                    cmd.ExecuteNonQuery();
                    cerrar_conexion();
                    response = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Método para listados (SELECT)
        public DataTable Consulta(string NombreSP, dynamic obj)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da;
            try
            {
                da = new MySqlDataAdapter(NombreSP, conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (obj != null)
                {
                    IDictionary<string, object> parametros = obj;
                    foreach (var property in parametros.Keys)
                    {
                        da.SelectCommand.Parameters.AddWithValue("_" + property, parametros[property]);
                    }
                }
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dt;
        }
    }
}
