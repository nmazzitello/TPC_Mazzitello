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
    public partial class DetallePrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Prestamo pres = new Prestamo();
            long idPres= (long) Session["sessionVerPrestamo"];
            NegocioPrestamo np = new NegocioPrestamo();
            pres = np.cargarPrestamo(idPres);

            if(pres.estado==false)
            {
                txtActivo.Text = "Préstamo finalizado";
            }
            else
            {
                txtActivo.Text = "Préstamo activo";
            }
            txtFecha.Text = pres.fecha.ToString("dd-MM-yyyy");
            txtCliente.Text = pres.cliente.apellido + ", " + pres.cliente.nombre+ " -Legajo: "+ pres.cliente.idCliente;
            txtMonto.Text = pres.monto.ToString();

            txtGastosAdm.Text = pres.gastosAdm.detalles;
        }

        //EVENTO PARA EL BOTON DE LA BARRA QUE LLEVA AL MENU PRINCIPAL--> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Remove("sessionVerPrestamo");
            Session.Remove("sesionCheck");

            int adm = (int)Session["soyAdm"];
            if (adm == 1)
            {
                Response.Redirect("PrincipalAdm.aspx");
            }
            Response.Redirect("PrincipalCliente.aspx");
        }

        //EVENTO PARA VER EL PRODUCTO EN GARANTIA --> 100%
        protected void btnVerProd_Click(object sender, EventArgs e)
        {
            Session.Add("sesionCheck", 1);
            Response.Redirect("AltaProducto.aspx");
        }

        //EVENTO PARA VER LAS CUOTAS PENDIENTES --> 100%
        protected void btnCuota_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerCuotaSPrestamo.aspx");
        }
    }
}