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
    public partial class VerCuotasPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Prestamo pres = new Prestamo();
                long idPres = (long)Session["sessionVerPrestamo"];
                NegocioPrestamo np = new NegocioPrestamo();
                pres = np.cargarPrestamo(idPres);
                NegocioValorCuota nv = new NegocioValorCuota();

                repeaterCuotaPrestamo.DataSource = nv.traerValorCuotas(idPres, pres.cantCuotas);
                repeaterCuotaPrestamo.DataBind();

                int adm = (int)Session["soyAdm"];
                if (adm == 1 || pres.estado==false)
                {
                    lblConfirmarPago.Visible = false;
                    btnTransf.Visible = false;
                    btnEfec.Visible = false;

                    if(adm==1)
                    {
                        btnFinalizar.Visible = true;
                    }
                }
            }
        }

        //EVENTO DEL BOTON DE LA BARRA PARA VOLVER AL MENU PRINCIPAL --> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Remove("sessionVerPrestamo");
            Session.Remove("sessionNumeroCuota");
            Session.Remove("sessionPrestamoCargado");

            int adm = (int)Session["soyAdm"];
            if (adm == 1)
            {
                Response.Redirect("PrincipalAdm.aspx");
            }
            Response.Redirect("PrincipalCliente.aspx");
        }

        //EVENTO DEL BOTON IR DE LA GRILLA --> 100%
        protected void btnIr_Click(object sender, EventArgs e)
        {
            int adm = (int)Session["soyAdm"];
            if (adm == 1)
            {

                //int numCuo = Convert.ToInt32(((Button)sender).CommandArgument);

                //val = nv.traerValorCuotas()

                //lblComprobantePago.Visible = true;
                //lblComprobantePago.Text = "Comprobante: ";
                //txtComprobantePago.Visible = true;
                //txtComprobantePago.Text = val.comprobantePago;
            }
            else
            {
                int numCuo = Convert.ToInt32(((Button)sender).CommandArgument);
                Session.Add("sessionNumeroCuota", numCuo);
            }
        }

        //EVENTO DEL BOTON PARA CONFIRMAR EL PAGO EN EFECTIVO -->
        protected void btnEfec_Click(object sender, EventArgs e)
        {
            lblComprobantePago.Visible = true;
            lblComprobantePago.Text = "Cargue la foto del recibo que le entrego nuestro representante:";
            txtComprobantePago.Visible = true;
            btnConfirmarPago.Visible = true;
        }

        //EVENTO DEL BOTON PARA CONFIRMAR EL PAGO MEDIANTE TRANSFERENCIA --> 100%
        protected void btnTransf_Click(object sender, EventArgs e)
        {
            lblComprobantePago.Visible = true;
            lblComprobantePago.Text = "Ingrese el número de comprobante: ";
            txtComprobantePago.Visible = true;
            btnConfirmarPago.Visible = true;
        }

        //EVENTO PARA EL BOTON CONFIRMAR PAGO QUE GUARDA EL COMPROBANTE DE PAGO DE ESA CUOTA --> 100%
        protected void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            int cuotaNum = (int)Session["sessionNumeroCuota"];
            Prestamo pre = new Prestamo();
            pre = (Prestamo)Session["sessionPrestamoCargado"];  //sesion que se carga en verPrestamo, btnVer_click
            NegocioValorCuota nv = new NegocioValorCuota();
            String comprobante = txtComprobantePago.Text;
            if(nv.confirmarPagoCuota(cuotaNum, pre.idPrestamo, comprobante)==true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Carga exitosa');", true);
                Session.Remove("sessionNumeroCuota");
                Session.Remove("sessionVerPrestamo");
                Session.Remove("sessionPrestamoCargado");
                Session.Remove("sessionVerPrestamo");
                Session.Remove("sesionCheck");
                Response.Redirect("AccionExitosa.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('MAlgo fallo');", true);
            }
        }

        //EVENTO PARA EL BOTON FINALIZAR CONTRATO --> 
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Prestamo pres = new Prestamo();
            long idPres = (long)Session["sessionVerPrestamo"];
            NegocioPrestamo np = new NegocioPrestamo();
            pres = np.cargarPrestamo(idPres);

            if(np.finalizarPrestamo(idPres, pres.cantCuotas)==true)
            {
                np.finalizarPrestamo(idPres);
                Response.Redirect("Finalizo.aspx");
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No es posible. Aún tiene cuotas pendientes');", true);
        }
    }

   
}