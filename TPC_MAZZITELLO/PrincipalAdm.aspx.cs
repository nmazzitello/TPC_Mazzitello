using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_MAZZITELLO
{
    public partial class PrincipalAdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["sesionUsuario"];
            if (user == null)
            {
                Response.Redirect("index.aspx");
            }
            lblUser.Text = "SESION DE: " + user.nombre;
        }

        //EVENTO PARA MODIFICAR LOS DATOS DE INICIO DE SESION DEL ADM --> 
        protected void btnDatosSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarDatosUsuario.aspx");
        }

        //EVENTO PARA VER/MODIFICAR LOS GASTOS ADMNISTRATIVOS --> 100%
        protected void btnGastosAdm_Click(object sender, EventArgs e)
        {
            Session.Add("sesionPrestamoEnProgreso", 0);
            Response.Redirect("DetallesGastosAdministrativos.aspx");
        }

        //EVENTO PARA VER LOS CLIENTES --> 
        protected void btnCliente_Click(object sender, EventArgs e)
        {
            Session.Add("sesionPrestamoEnProgreso", 0);
            Response.Redirect("DetallesCliente.aspx");
        }

        //EVENTO PARA CREAR UN PRESTAMO NUEVO --> 
        protected void btnNuevoPres_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaPrestamo.aspx");
        }

        //EVENTO PARA VER TODAS LAS SOLICITUDES --> 
        protected void btnSolicitud_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerSolicitudes.aspx");
        }

        //EVENTO PARA VER TODOS LOS PRESTAMOS --> 
        protected void btnPrestamo_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerPrestamos.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Add("sesionUsuario", null);
            Session.Add("sesionCliente", null);
            Response.Redirect("index.aspx");
        }
    }
}