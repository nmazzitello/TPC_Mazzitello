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
    public partial class DetallesCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                NegocioCliente nc = new NegocioCliente();
                repeaterCliente.DataSource = nc.traerClientes();
                repeaterCliente.DataBind();
            }
        }

        //EVENTO PARA EL BOTON SELECCIONAR DE LA GRILLA- SI ESTA GENERANDO UN PRESTAMO, CARGA ESE CLIENTE EN UN OBJ Y VUELVE A CARGAR LOS DATOS
        //DEL PRESTAMO. DE LO CONTRARIO, PUEDE VER LOS DATOS PERSONALES DEL CLIENTE -->
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            NegocioCliente nc = new NegocioCliente();
            long idCli = Convert.ToInt64(((Button)sender).CommandArgument);
            Cliente cli = new Cliente();

            cli = nc.cargarCliente(idCli); //carga en cli, un objeto cliente por el id de la fila seleccionada
            
            int prestamoActivo = (int)Session["sesionPrestamoEnProgreso"];  //se carga la sesion de prestamo en progreso, si es 1, 
                                                                            //entro para cargar el cliente del prestamo, de lo contrario -0- 
                                                                             //quiere ver los datos del cliente
            if (prestamoActivo == 1)
            {
                Session.Add("sesionClientePrestamo", cli); // se carga el cliente que se va a usar para el prestamo y vuelve a altaPrestamo
                Response.Redirect("AltaPrestamo.aspx");
            }
            else
            {
                Session.Add("sesionCliente", cli);
                Response.Redirect("DatosPersonales.aspx");
            }
        }

        //EVENTO DEL BOTON DE LA BARRA PARA IR AL MENU PRINCIPAL --> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            int adm = (int)Session["soyAdm"];
            if (adm == 0)
            {
                Response.Redirect("PrincipalCliente.aspx");
            }
            Response.Redirect("PrincipalAdm.aspx");
        }
    }
}