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
    public partial class DetallesGastosAdministrativos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioGastosAdm nga = new NegocioGastosAdm();
                repeaterGastosAdm.DataSource = nga.traerGastosAdm();
                repeaterGastosAdm.DataBind();
            }

            int prestamoActivo = (int)Session["sesionPrestamoEnProgreso"];
            if (prestamoActivo == 1)
            {
                lblSubt.Visible = false;
                lblMonto.Visible = false;
                txtMonto.Visible = false;
                lblMeses.Visible = false;
                txtMeses.Visible = false;
                lblDetalles.Visible = false;
                txtDetalles.Visible = false;
                btnAceptar.Visible = false;
            }
        }

        //EVENTO PARA EL BOTON ACEPTAR --> 
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            GastosAdministrativos gadm = new GastosAdministrativos();
            NegocioGastosAdm ng = new NegocioGastosAdm();

            gadm=(GastosAdministrativos)Session["sesionGasAdm"];

            if(gadm!=null)
            {
                gadm.monto = txtMonto.Text;
                gadm.meses = Int32.Parse(txtMeses.Text);
                gadm.detalles = txtDetalles.Text;
                ng.modificarGastoAdm(gadm);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Modificacion exitosa');", true);
                Response.Redirect("DetallesGastosAdministrativos.aspx");
            }
            else
            {
                if(!txtMonto.Text.Equals(""))
                {
                    if(!txtMeses.Text.Equals(""))
                    {
                        if(!txtDetalles.Text.Equals(""))
                        {
                            gadm.monto = txtMonto.Text;
                            gadm.meses = Int32.Parse(txtMeses.Text);
                            gadm.detalles = txtDetalles.Text;

                            if (ng.agregarGastoAdm(gadm) == true)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Agregado correctamente');", true);
                                Response.Redirect("DetallesGastosAdministrativos.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo fallo man');", true);
                            }
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Indique los meses');", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Indique el monto');", true);


            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            GastosAdministrativos gadm = new GastosAdministrativos();
            NegocioGastosAdm ng = new NegocioGastosAdm();

            int idEsco = Convert.ToInt32(((Button)sender).CommandArgument);
            gadm = ng.cargarGastoAdm(idEsco);

            int prestamoActivo = (int)Session["sesionPrestamoEnProgreso"];  //se carga la sesion de prestamo en progreso, si es 1, 
                                                                            //entro para cargar el cliente del prestamo, de lo contrario -0- 
                                                                            //quiere ver los datos del cliente
            if(prestamoActivo==1)
            {
                Session.Add("sesionGastosAdmPrestamo", gadm); // se carga el cliente que se va a usar para el prestamo y vuelve a altaPrestamo
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Gastos administrativos cargados con exito.');", true);
                Response.Redirect("AltaPrestamo.aspx");
            }
            else
            {
                Session.Add("sesionGasAdm", gadm);

                txtMonto.Text = gadm.monto;
                txtMeses.Text = gadm.meses.ToString();
                txtDetalles.Text = gadm.detalles;
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrincipalAdm.aspx");
        }
    }
}