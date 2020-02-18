using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class SisListasService : ISisListas
    {
        SisListas srv = new SisListas();
        public List<SisListas> GetList(string id)
        {
            List<SisListas> _list = srv.GetList(id);
            return _list;
        }

        public List<SisListas> GetListByCampo(string campo)
        {
            List<SisListas> _list = srv.GetListByCampo(campo);
            return _list;
        }

        public SisListas GetOne(string idEmpresa, string id)
        {
            SisListas _one = srv.GetOne(idEmpresa, id);
            return _one;
        }

        public string SetOne(SisListas one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
