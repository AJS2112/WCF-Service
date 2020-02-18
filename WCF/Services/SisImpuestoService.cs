using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class SisImpuestoService : ISisImpuesto
    {
        SisImpuesto srv = new SisImpuesto();
        public List<SisImpuesto> GetList(string id)
        {
            List<SisImpuesto> _list = srv.GetList(id);
            return _list;
        }
    }
}
