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
    public partial class AltaPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("sesionPrestamoEnProgreso", 1);

            if (!IsPostBack)
            {
                ListItem g, h, i, j;
                g = new ListItem("0", "0");
                h = new ListItem("1", "1");
                i = new ListItem("2", "2");
                j = new ListItem("3", "3");
                ddlCantidadCuotas.Items.Add(g);
                ddlCantidadCuotas.Items.Add(h);
                ddlCantidadCuotas.Items.Add(i);
                ddlCantidadCuotas.Items.Add(j);
            }

            if (Session["sesionVengoDeAceptarSolicitud"] != null)   //sesion que se carga en altaSolicitudPrestamo en el evento btnConfirmar
            {
                NegocioSolicitud ns = new NegocioSolicitud();
                Solicitud sol = new Solicitud();
                long idSol = (long)Session["sessionIdSolicitud"];
                sol = ns.cargarSolicitud(idSol);

                btnSelCliente.Visible = false;
                btnProd.Visible = false;

                txtMonto.Text = sol.montoSolicitado;
                txtMonto.Enabled = false;
                ddlCantidadCuotas.SelectedIndex = sol.cantidadCuotas;
                ddlCantidadCuotas.Enabled = false;
                Session.Add("sesionClientePrestamo", sol.cliente);
                Session.Add("sesionProductoPrestamo", sol.producto);
            }

            String mont=(String)Session["sesionMontoPrestam"];
            if(mont!=null)
            {
                txtMonto.Text = mont.ToString();
            }
            if(Session["sesionCantidadCuotasPrestamo"]!=null)
            {
                int cantiCuo = (int)Session["sesionCantidadCuotasPrestamo"];
                ddlCantidadCuotas.SelectedIndex = cantiCuo;
            }
            Cliente cli = (Cliente)Session["sesionClientePrestamo"];
            if (cli!= null)
            {
                lblCli.Text = "NUMERO CLIENTE: " + cli.idCliente + "- APELLIDO: " + cli.apellido;
            }
            GastosAdministrativos gad = (GastosAdministrativos)Session["sesionGastosAdmPrestamo"];
            if(gad!= null)
            {
                lblGasAdm.Text = "GASTOS ADMINISTRATIVOS: " + gad.detalles;
                btnGastosAdm.Text = "CAMBIAR";
            }
            Producto pro = (Producto)Session["sesionProductoPrestamo"];
            if(pro!= null)
            {
                lblProGar.Text = "PRODUCTO: " + pro.producto;
                btnProd.Text = "CAMBIAR";
            }
            List<ValorCuota>val = (List<ValorCuota>)Session["sesionValorCuotaPrestamo"];
            if(val!= null)
            {
                lblValCuo.Text = "VALOR CUOTAS: Calculado";
            }
            if (Session["sesionCuotasPrestamo"] != null)
            {
                int cuo = (int)Session["sesionCuotasPrestamo"];
                ddlCantidadCuotas.SelectedIndex = cuo;// falta chequear ciertas cosas
            }
        }

        //EVENTO PARA EL BOTON DE SELECCIONAR EL CLIENTE QUE RECIBE EL PRESTAMO --> 100%
        protected void btnSelCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetallesCliente.aspx");
        }

        //EVENTO PARA EL BOTON DE SELECCIONAR LA OPCION DE GASTOS ADMINISTRATIVOS ELEGIDA POR EL CLIENTE --> 100%
        protected void btnGastosAdm_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetallesGastosAdministrativos.aspx");
        }

        //EVENTO PARA CARGAR LOS PRODUCTOS DEL CLIENTE SELECCIONADO --> 100%
        protected void btnProd_Click(object sender, EventArgs e)
        {
            Cliente cli = (Cliente)Session["sesionClientePrestamo"];
            if (cli!=null)
            {
                Session.Add("sesionCliente",cli);
                Response.Redirect("AltaProducto.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Seleccione primero el cliente.');", true);
            }
        }

        //EVENTO PARA CARGAR EL VALOR DE LAS CUOTAS --> 100%
        protected void btnValorCuo_Click(object sender, EventArgs e)
        {
            String mon = txtMonto.Text;

            if (!mon.Equals(""))
            {
                int canCuo = ddlCantidadCuotas.SelectedIndex;
                if (canCuo != 0)
                {
                    GastosAdministrativos gad = (GastosAdministrativos)Session["sesionGastosAdmPrestamo"];
                    if (gad != null)
                    {
                        double montoConDec = double.Parse(mon);
                        int monto = (int)montoConDec;

                        Session.Add("sesionMontoPrestamo", monto);
                        int cantCuot = ddlCantidadCuotas.SelectedIndex;
                        Session.Add("sesionCuotasPrestamo", cantCuot);
                        Response.Redirect("AgregarValorCuotas.aspx");
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Seleccione los gastos administrativos.');", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Seleccione la cantidad de cuotas.');", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Seleccione el monto del credito.');", true);
        }
  
        //EVENTO PARA CONFIRMAR LA CARGA DEL PRESTAMO --> 100%
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Cliente cli = (Cliente)Session["sesionClientePrestamo"];
            if (cli != null)
            {
                Producto pro = (Producto)Session["sesionProductoPrestamo"];
                if (pro != null)
                {
                    GastosAdministrativos gad = (GastosAdministrativos)Session["sesionGastosAdmPrestamo"];
                    if (gad != null)
                    {
                        if (!txtMonto.Text.Equals(""))
                        {
                            if (ddlCantidadCuotas.SelectedIndex != 0)
                            {
                                List<ValorCuota> livc = (List<ValorCuota>)Session["sesionValorCuotaPrestamo"];
                                if(livc!=null)
                                {
                                    NegocioPrestamo np = new NegocioPrestamo();
                                    if(np.verificarSiTieneActivoPrestamo(cli.idCliente)==false)
                                    {
                                        Prestamo pre = new Prestamo();

                                        pre.monto = Int32.Parse(txtMonto.Text);
                                        pre.cantCuotas = ddlCantidadCuotas.SelectedIndex;
                                        pre.gastosAdm = gad;
                                        pre.datosCuota = livc;
                                        pre.prodGarantia = pro;
                                        pre.cliente = cli;

                                        if (np.generarPrestamo(pre) == true)
                                        {
                                            NegocioValorCuota nv = new NegocioValorCuota();
                                            long idPres = np.obtenerIdDelPrestamo();
                                            nv.guardarValorCuota(livc, idPres, pre.cantCuotas);

                                            NegocioSolicitud ns = new NegocioSolicitud();
                                            long idSol = (long)Session["sessionIdSolicitud"];
                                            ns.cambiarSoliDePendienteAAprobada(idSol);

                                            Session.Add("sesionClientePrestamo", null);     //se limpian las sesiones para poder generar un nuevo
                                            Session.Add("sesionGastosAdmPrestamo", null);   //si se desea
                                            Session.Add("sesionGastosAdmPrestamo", null);
                                            Session.Add("sesionValorCuotaPrestamo", null);
                                            Response.Redirect("Confirmacion.aspx");
                                        }
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Algo fallo.');", true);
                                    }
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Falló creacion préstamo. Aún tiene un préstamo activo el cliente.');", true);
                                }
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Falta cargar las cuotas.');", true);
                            }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Seleccione la cantidad cuotas.');", true); 
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Falta cargar el monto.');", true);
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Falta cargar los gastos administrativos.');", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Falta seleccionar el producto.');", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Falta cargar cliente.');", true);
        }

        //EVENTO DEL BOTON DE LA BARRA QUE LLEVA AL INICIO --> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Remove("sesionClientePrestamo");
            Session.Remove("sesionProductoPrestamo");
            Session.Remove("sesionGastosAdmPrestamo");
            Session.Remove("sesionMontoPrestam");
            Session.Remove("sesionCuotasPrestamo");
            Session.Remove("sesionValorCuotaPrestamo");
            Response.Redirect("PrincipalAdm.aspx");
        }

        //EVENTO PARA FORZAR AL USUARIO A QUE EL MONTO INGRESADO SEA MAYOR A 1000 Y MULTIPLO DE ESTE --> 100%
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
    }
}