using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_MAZZITELLO
{
    public partial class VerSolicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = (Usuario)Session["sesionUsuario"];
            if(usu==null)
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                int adm = (int)Session["soyAdm"];
                if(adm==1)
                {
                    NegocioSolicitud ns = new NegocioSolicitud();
                    repeaterSolicitud.DataSource = ns.listarSolicitudesConView();
                    repeaterSolicitud.DataBind();
                }
                else
                {
                    NegocioSolicitud ns = new NegocioSolicitud();
                    repeaterSolicitud.DataSource = ns.listarSolicitudesDeCliente(usu.idUsuario);
                    repeaterSolicitud.DataBind();
                }
            }
        }

        //EVENTO PARA EL BOTON CHEQUEAR DEL GRID --> 100%
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            long idSol = Convert.ToInt64(((Button)sender).CommandArgument);
            Session.Add("sessionIdSolicitud", idSol);
            Session.Add("sesionCheck", 1);

            Response.Redirect("AltaSolicitudPrestamo.aspx");
        }

        //EVENTO PARA EL BOTON DE LA BARRA PARA VOLVER AL MENU PRINCIPAL --> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Remove("sessionIdSolicitud");
            Session.Remove("sesionCheck");

            int adm = (int)Session["soyAdm"];
            if (adm == 1)
            {
                Response.Redirect("PrincipalAdm.aspx");
            }
            else
            {
                Response.Redirect("PrincipalCliente.aspx");
            }
        }
    }
}