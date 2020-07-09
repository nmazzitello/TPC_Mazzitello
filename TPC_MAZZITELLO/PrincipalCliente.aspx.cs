using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_MAZZITELLO
{
    public partial class PrincipalCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("sesionPrestamoEnProgreso", 0);

            Usuario user = (Usuario)Session["sesionUsuario"];
            if (user == null)
            {
                Response.Redirect("index.aspx");
            }
            lblUser.Text ="SESION DE: "+ user.nombre;
        }

        //EVENTO PARA EL BOTON IR A DATOS DE CLIENTE --> 100%
        protected void btnDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("DatosPersonales.aspx");
        }

        //EVENTO PARA EL BOTON SOLICITAR PRESTAMO --> 100%
        protected void btnPrestamo_Click(object sender, EventArgs e)
        {
            Cliente cli = (Cliente)Session["sesionCliente"];

            if(!cli.apellido.Equals("apellidoVacio"))
            {
                NegocioSolicitud ns = new NegocioSolicitud();
                if (ns.verificarSolicitudUltima(cli.idCliente) == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Su solicitud aún se encuentra pendiente de verificacion.');", true);
                }
                else
                {
                    NegocioPrestamo np = new NegocioPrestamo();
                    if(np.verificarSiTieneActivoPrestamo(cli.idCliente)==true)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Aún tiene un préstamo activo');", true);
                    }
                    else
                    {
                        Usuario user = (Usuario)Session["sesionUsuario"];
                        NegocioCliente nc = new NegocioCliente();
                        Session.Add("sesionSolicitar", 1);
                        Response.Redirect("AltaSolicitudPrestamo.aspx");
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Primero debes completar tus datos personales.');", true);
        }

        //EVENTO PARA EL BOTON DE VER LOS PRESTAMOS --> 100%
        protected void btnVerPrestamos_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerPrestamos.aspx");
        }

        //EVENTO PARA SIMULAR UN CREDITO --> 100%
        protected void btnSimular_Click(object sender, EventArgs e)
        {
            Response.Redirect("SimulacionPrestamo.aspx");
        }

        //CERRAR SESION --> 100%
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Add("sesionUsuario", null);
            Session.Add("sesionCliente", null);
            Response.Redirect("index.aspx");
        }

        //EVENTO PARA IR A VER LAS SOLICITUDES --> 100%
        protected void btnVerSolicitud_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerSolicitudes.aspx");
        }

        //EVENTO PARA VER LOS PRODUCTOS, MODIFICARLOS O AGREGAR UNO NUEVO --> 100%
        protected void btnVerProductos_Click(object sender, EventArgs e)
        {
            Session.Add("sessionVerProductos", 1);
            Response.Redirect("AltaProducto.aspx");
        }
    }
}