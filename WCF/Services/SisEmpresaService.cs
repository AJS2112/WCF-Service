using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class SisEmpresaService : ISisEmpresa
    {
        SisEmpresa srv = new SisEmpresa();
        public SisEmpresa GetOne(string id)
        {
            SisEmpresa _one = srv.GetOne(id);
            return _one;
        }

        public string SetOne(SisEmpresa one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
