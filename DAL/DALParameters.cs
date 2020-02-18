using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALParameters
    {
        public String Nombre { get; set; }
        public Object Valor { get; set; }

        public DALParameters(String objNombre, Object objValor)
        {
            Nombre = objNombre;
            Valor = objValor;
        }
    }
}
