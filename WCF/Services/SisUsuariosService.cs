using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class SisUsuariosService : ISisUsuarios
    {
        SisUsuarios srv = new SisUsuarios();
        public List<SisUsuarios> GetList(string idEmpresa)
        {
            List<SisUsuarios> _list = srv.GetList(idEmpresa);
            return _list;
        }
        public SisUsuarios Login(string logname, string pass)
        {
            SisUsuarios _one = srv.Login(logname,pass);
            return _one;
        }
    }
}
