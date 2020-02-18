using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class CnfCuentaBancariaService : ICnfCuentaBancaria
    {
        CnfCuentaBancaria srv = new CnfCuentaBancaria();
        public List<CnfCuentaBancaria> GetList(string idEmpresa)
        {
            List<CnfCuentaBancaria> _list = srv.GetList(idEmpresa);
            return _list;
        }

        public CnfCuentaBancaria GetOne(string idEmpresa, string id)
        {
            CnfCuentaBancaria _one = srv.GetOne(idEmpresa, id);
            return _one;
        }

        public string SetOne(CnfCuentaBancaria one)
        {
            string _id = srv.SetOne(one);
            return _id;
        }
    }
}
