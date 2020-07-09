using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_MAZZITELLO
{
    public partial class VerPrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int adm = (int)Session["soyAdm"];
                if(adm==1)
                {
                    NegocioPrestamo np = new NegocioPrestamo();
                    repeaterPrestamo.DataSource = np.listarPrestamos();
                    repeaterPrestamo.DataBind();
                }
                else
                {
                    Cliente cli = (Cliente)Session["sesionCliente"];

                    NegocioPrestamo np = new NegocioPrestamo();
                    repeaterPrestamo.DataSource = np.listarPrestamosDeCliente(cli.idCliente);
                    repeaterPrestamo.DataBind();
                }
            }
        }

        //EVENTO BOTON VER PRESTAMO DEL GRID --> 100%
        protected void btnVer_Click(object sender, EventArgs e)
        {
            long idPres = Convert.ToInt64(((Button)sender).CommandArgument);
            NegocioPrestamo np = new NegocioPrestamo();
            Prestamo pre = new Prestamo();
            pre = np.cargarPrestamo(idPres);
            Session.Add("sessionPrestamoCargado", pre);

            Session.Add("sessionVerPrestamo", idPres);
            Response.Redirect("DetallePrestamo.aspx");
        }

        //EVENTO PARA EL BOTON DE LA BARRA QUE LLEVA AL MENU PRINCIPAL --> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Remove("sessionPrestamoCargado");
            Session.Remove("sessionVerPrestamo");

            int adm = (int)Session["soyAdm"];
            if (adm == 1)
            {
                Response.Redirect("PrincipalAdm.aspx");
            }
            Response.Redirect("PrincipalCliente.aspx");

        }
    }
}