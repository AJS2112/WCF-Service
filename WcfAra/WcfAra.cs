using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WCF;

namespace WcfAra
{
    public partial class WcfAra : ServiceBase
    {
        public WcfAra()
        {
            InitializeComponent();
        }

        ServiceHost CajMovimientoHost;
        ServiceHost CajOperacionHost;
        ServiceHost CmpOperacionHost;
        ServiceHost CmpProveedorHost;
        ServiceHost CnfCotizacionHost;
        ServiceHost CnfCuentaBancariaHost;

        ServiceHost ColMovimientoHost;
        ServiceHost ColNotificacionHost;
        ServiceHost ColOperacionHost;

        ServiceHost InvCategoriaHost;
        ServiceHost InvMovimientoHost;
        ServiceHost InvOperacionHost;
        ServiceHost InvProductoHost;
        ServiceHost RepCajaHost;
        ServiceHost RepCompraHost;
        ServiceHost RepDashboardHost;
        ServiceHost RepInventarioHost;
        ServiceHost RepVentaHost;
        ServiceHost SisEmpresaHost;
        ServiceHost SisImpuestoHost;
        ServiceHost SisListasHost;
        ServiceHost SisOperacionHost;
        ServiceHost SisUsuariosHost;
        ServiceHost VntClienteHost;
        ServiceHost VntOperacionHost;

        protected override void OnStart(string[] args)
        {
            CajMovimientoHost = new ServiceHost(typeof(CajMovimientoService));
            CajOperacionHost = new ServiceHost(typeof(CajOperacionService));

            CmpOperacionHost = new ServiceHost(typeof(CmpOperacionService));
            CmpProveedorHost = new ServiceHost(typeof(CmpProveedorService));

            CnfCotizacionHost = new ServiceHost(typeof(CnfCotizacionService));
            CnfCuentaBancariaHost = new ServiceHost(typeof(CnfCuentaBancariaService));

            ColMovimientoHost = new ServiceHost(typeof(ColMovimientoService));
            ColNotificacionHost = new ServiceHost(typeof(ColNotificacionService));
            ColOperacionHost = new ServiceHost(typeof(ColOperacionService));

            InvCategoriaHost = new ServiceHost(typeof(InvCategoriaService));
            InvMovimientoHost = new ServiceHost(typeof(InvMovimientoService));
            InvOperacionHost = new ServiceHost(typeof(InvOperacionService));
            InvProductoHost = new ServiceHost(typeof(InvProductoService));

            RepCajaHost = new ServiceHost(typeof(RepCajaService));
            RepCompraHost = new ServiceHost(typeof(RepCompraService));
            RepDashboardHost = new ServiceHost(typeof(RepDashboardService));
            RepInventarioHost = new ServiceHost(typeof(RepInventarioService));
            RepVentaHost = new ServiceHost(typeof(RepVentaService));

            SisEmpresaHost = new ServiceHost(typeof(SisEmpresaService));
            SisImpuestoHost = new ServiceHost(typeof(SisImpuestoService));
            SisListasHost = new ServiceHost(typeof(SisListasService));
            SisOperacionHost = new ServiceHost(typeof(SisOperacionService));
            SisUsuariosHost = new ServiceHost(typeof(SisUsuariosService));

            VntClienteHost = new ServiceHost(typeof(VntClienteService));
            VntOperacionHost = new ServiceHost(typeof(VntOperacionService));


            CajMovimientoHost.Open();
            CajOperacionHost.Open();

            CmpOperacionHost.Open();
            CmpProveedorHost.Open();

            CnfCotizacionHost.Open();
            CnfCuentaBancariaHost.Open();

            ColMovimientoHost.Open();
            ColNotificacionHost.Open();
            ColOperacionHost.Open();

            InvCategoriaHost.Open();
            InvMovimientoHost.Open();
            InvOperacionHost.Open();
            InvProductoHost.Open();

            RepCajaHost.Open();
            RepCompraHost.Open();
            RepDashboardHost.Open();
            RepInventarioHost.Open();
            RepVentaHost.Open();

            SisEmpresaHost.Open();
            SisImpuestoHost.Open();
            SisListasHost.Open();
            SisOperacionHost.Open();
            SisUsuariosHost.Open();

            VntClienteHost.Open();
            VntOperacionHost.Open();

        }

        protected override void OnStop()
        {
            CajMovimientoHost.Close();
            CajOperacionHost.Close();

            CmpOperacionHost.Close();
            CmpProveedorHost.Close();

            CnfCotizacionHost.Close();
            CnfCuentaBancariaHost.Close();

            ColMovimientoHost.Close();
            ColNotificacionHost.Close();
            ColOperacionHost.Close();

            InvCategoriaHost.Close();
            InvMovimientoHost.Close();
            InvOperacionHost.Close();
            InvProductoHost.Close();

            RepCajaHost.Close();
            RepCompraHost.Close();
            RepDashboardHost.Close();
            RepInventarioHost.Close();
            RepVentaHost.Close();

            SisEmpresaHost.Close();
            SisImpuestoHost.Close();
            SisListasHost.Close();
            SisOperacionHost.Close();
            SisUsuariosHost.Close();

            VntClienteHost.Close();
            VntOperacionHost.Close();
        }
    }
}
