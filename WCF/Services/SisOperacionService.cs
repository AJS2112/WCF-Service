using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class SisOperacionService : ISisOperacion
    {
        SisOperacion srv = new SisOperacion();
        public List<SisOperacion> GetList(string idTipo)
        {
            List<SisOperacion> _list = srv.GetList(idTipo);
            return _list;
        }

        public SisOperacion GetOne(string id)
        {
            SisOperacion _one = srv.GetOne(id);
            return _one;
        }

        public string SetOne(SisOperacion one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
