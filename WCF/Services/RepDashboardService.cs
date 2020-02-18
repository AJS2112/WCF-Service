using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Entities;

namespace WCF
{
    public class RepDashboardService : IRepDashboard
    {
        RepDashboard srv = new RepDashboard();

        public List<RepDashboard> GetResumenCaja(string idEmpresa, string desde, string hasta)
        {
            List<RepDashboard> _list = srv.GetResumenCaja(idEmpresa, desde, hasta);
            return _list;
        }

        public List<RepDashboard> GetResumenGeneral(string idEmpresa, string desde, string hasta)
        {
            List<RepDashboard> _list = srv.GetResumenGeneral(idEmpresa, desde, hasta);
            return _list;
        }
    }
}
