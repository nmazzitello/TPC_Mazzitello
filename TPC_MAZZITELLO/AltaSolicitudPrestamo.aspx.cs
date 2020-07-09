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
    public partial class AltaSolicitudPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["sesionUsuario"];
            if (user == null)
            {
                Response.Redirect("index.aspx");
            }

            //txtProducto.Enabled = false;
            if (!IsPostBack)
            {
                ListItem g, h, i, j;
                g = new ListItem("0", "0");
                h = new ListItem("1", "1");
                i = new ListItem("2", "2");
                j = new ListItem("3", "3");
                ddlCantCuotas.Items.Add(g);
                ddlCantCuotas.Items.Add(h);
                ddlCantCuotas.Items.Add(i);
                ddlCantCuotas.Items.Add(j);

                //NegocioGastosAdm ngad = new NegocioGastosAdm();
                //ddlGastosAdm.DataSource = ngad.traerGastosAdm();
                //ddlGastosAdm.DataTextField = "detalles";
                //ddlGastosAdm.DataValueField = "idGastosAdm";
                //ddlGastosAdm.DataBind();
            }

            int chk = 0;   //variable que se utiliza para ver si entro desde el boton chequear del grid
            if (Session["sesionCheck"]!= null)
            {
                chk = (int)Session["sesionCheck"];  //variable que se crea en el evento btnCheck en verSolicitudes
            }
            int adm = (int)Session["soyAdm"];
            
            if(adm==1 || chk==1)
            {
                NegocioSolicitud ns = new NegocioSolicitud();
                Solicitud sol = new Solicitud();
                long idSol = (long)Session["sessionIdSolicitud"];
                sol = ns.cargarSolicitud(idSol);

                lblTitulo.Text = "SOLICITUD";
                txtMonto.Text = sol.montoSolicitado.ToString();
                ddlCantCuotas.SelectedIndex = sol.cantidadCuotas;
                ddlCantCuotas.Enabled = false;
                txtProducto.Text = sol.producto.producto;
                txtMonto.Enabled = false;
                btnAceptar.Visible = false;
                btnAgregarProducto.Text = "VER PRODUCTO";

                if(adm==0)
                {
                    btnRechazar.Visible = false;
                    btnConfirmar.Visible=false;
                }

                if(sol.estado==0) // se rechazo
                {
                    btnRechazar.Visible = false;
                    btnConfirmar.Visible = false;
                    lblObservaciones.Visible = true;
                    txtObservaciones.Visible = true;
                    txtObservaciones.Text = sol.observacion;
                    txtObservaciones.Enabled = false;
                }
            }
            else
            {
                btnRechazar.Visible = false;
                btnConfirmar.Visible = false;

                if (Session["sesionProducto"] != null)
                {
                    Producto prod = (Producto)Session["sesionProducto"];
                    txtProducto.Text = prod.producto;
                }
                String mont = (String)Session["sesionMonto"];
                if (mont != null)
                {
                    txtMonto.Text = mont.ToString();
                }
                if (Session["sesionCantidadCuotas"] != null)
                {
                    int cuo = (int)Session["sesionCantidadCuotas"];
                    ddlCantCuotas.SelectedIndex = cuo;// falta chequear ciertas cosas
                }
            }
        }

        //EVENTO PARA EL BOTON AGREGAR PRODUCTO --> 100%
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            int adm = (int)Session["soyAdm"];
            int chk = 0;
            if (Session["sesionCheck"] != null)
            {
                chk = (int)Session["sesionCheck"];  //variable que se crea en el evento btnCheck en verSolicitudes
            }

            if (adm == 1 || chk == 1)
            {
                Response.Redirect("AltaProducto.aspx");
            }
            else
            {
                String mon = txtMonto.Text.ToString();
                int cuo = ddlCantCuotas.SelectedIndex;

                Session.Add("sesionMonto", mon);
                Session.Add("sesionCantidadCuotas", cuo);
                Response.Redirect("AltaProducto.aspx");
            } 
        }

        //EVENTO PARA EL BOTON CONFIRMAR SOLICITUD --> 100%
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Cliente cli = (Cliente)Session["sesionCliente"];
            Producto pro = (Producto)Session["sesionProducto"];

            Solicitud soli = new Solicitud();
            NegocioSolicitud ns = new NegocioSolicitud();

            if (!txtMonto.Text.Equals(""))
            {
                if(ddlCantCuotas.SelectedIndex!=0)
                {
                    if (!txtProducto.Text.Equals(""))
                    {
                        //NegocioGastosAdm ng = new NegocioGastosAdm();
                        //GastosAdministrativos gad = new GastosAdministrativos();
                        //if(ddlGastosAdm.SelectedIndex==0)
                        //{
                        //    gad = ng.cargarGastoAdm(1);
                        //}
                        //else
                        //{
                        //    gad = ng.cargarGastoAdm(2);
                        //}
                        //soli.gastosAdm = gad;
                        soli.producto = pro;
                        soli.montoSolicitado = txtMonto.Text;
                        soli.cliente = cli;
                        soli.cantidadCuotas = ddlCantCuotas.SelectedIndex;

                        soli.estado = 2;
                        soli.producto = pro;
                        if (ns.guardarSolicitud(soli) == true)
                        {
                            Session.Add("sesionCantidadCuotas", null);
                            Session.Add("sesionMonto", null);
                            Session.Add("sesionProducto", null);
                            Response.Redirect("Confirmacion.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo falto.');", true);
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Seleccione el producto.');", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Seleccione cantidad de cuotas.');", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Seleccione el monto.');", true);
        }

        //EVENTO PARA EL BOTON DE IR AL INICIO DE LA BARRA --> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Remove("sessionIdSolicitud");
            Session.Remove("sesionCheck");
            Session.Remove("sesionProducto");
            Session.Remove("sesionMonto");
            Session.Remove("sesionCantidadCuotas");
            Session.Remove("sesionMontoPrestam");
            Session.Remove("sesionVengoDeAceptarSolicitud");

            int adm = (int)Session["soyAdm"];
            if (adm==0)
            {
                Response.Redirect("PrincipalCliente.aspx");
            }
            else
            {
                Response.Redirect("PrincipalAdm.aspx");
            }
        }

        //EVENTO QUE VALIDA QUE EL MONTO SEA MAYOR A 1000 Y MULTIPLO DE ESTE --> 100%
        protected void txtMonto_TextChanged(object sender, EventArgs e)
        {
            String mon = txtMonto.Text;
            int monInt = Int32.Parse(mon);

            if (monInt >= 1000)
            {
                if (monInt % 1000 == 0)
                {
                    if (!txtMonto.Text.Equals(""))
                    {
                        Session.Add("sesionMontoPrestam", mon);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El monto solicitado debe ser una cifra redonda (multiplos de $1000).');", true);
                    txtMonto.Text = "";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El monto debe ser superor a los $1000');", true);
                txtMonto.Text = "";
            }
        }

        //EVENTO PARA EL BOTON CONFIRMAR SOLICITUD -->
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Session.Add("sesionVengoDeAceptarSolicitud", 1);
            Response.Redirect("AltaPrestamo.aspx");
        }

        //EVENTO DEL BOTON RECHAZAR, QUE PERMITE AL ADM EXPLICAR EL MOTIVO DEL RECHAZO --> 100%
        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            lblObservaciones.Visible = true;
            txtObservaciones.Visible = true;
            btnEnviarObs.Visible = true;
        }

        // EVENTO PARA EL BOTON ENVIAR OBSERVACIONES DEL ADM AL MOMENTO DE RECHAZAR EL CONTRATO--> 100% 
        protected void btnEnviarObs_Click(object sender, EventArgs e) 
        {
            if(!txtObservaciones.Text.Equals(""))
            {
                long idSol = (long)Session["sessionIdSolicitud"];
                String obser = txtObservaciones.Text.ToString();
                NegocioSolicitud ns = new NegocioSolicitud();
                ns.rechazarSolicitud(idSol, obser);
                Response.Redirect("PrincipalAdm.aspx");
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Complete la razón del rechazo');", true);
        }
    }
}