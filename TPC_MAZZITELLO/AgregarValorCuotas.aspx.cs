using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_MAZZITELLO
{
    public partial class AgregarValorCuotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GastosAdministrativos gad = (GastosAdministrativos)Session["sesionGastosAdmPrestamo"];

            int montoSolicitado = (int)Session["sesionMontoPrestamo"];
            int monto = montoSolicitado + (montoSolicitado/2);
            int cuotas= (int)Session["sesionCuotasPrestamo"];

            double montoGasAdm = Convert.ToDouble(gad.monto);

            double cu1, cu1Atr, cu1Ven, cu2, cu2Atr, cu2Ven, cu3, cu3Atr, cu3Ven, montoPar, fgad;

            if(cuotas==1)
            {
                lbl4.Visible = false;
                lbl5.Visible = false;
                lbl6.Visible = false;
                lbl7.Visible = false;
                lbl8.Visible = false;
                lbl9.Visible = false;
                txtCuotaDos.Visible = false;
                txtCuotaDosAtrasada.Visible = false;
                txtCuotaDosVencida.Visible = false;
                txtCuotaTres.Visible = false;
                txtCuotaTresAtrasada.Visible = false;
                txtCuotaTresVencida.Visible = false;
            }
            else if(cuotas==2)
            {
                lbl7.Visible = false;
                lbl8.Visible = false;
                lbl9.Visible = false;
                txtCuotaTres.Visible = false;
                txtCuotaTresAtrasada.Visible = false;
                txtCuotaTresVencida.Visible = false;
            }

            if(gad.meses==1)
            {
                if (cuotas==1)
                {
                    cu1 = monto + montoGasAdm;
                    cu1Atr = (cu1)*1.3;
                    cu1Ven = (cu1) * 1.6;

                    txtCuotaUno.Text = cu1.ToString();
                    txtCuotaUnoAtrasada.Text = cu1Atr.ToString();
                    txtCuotaUnoVencida.Text=cu1Ven.ToString();
                }
                else if(cuotas==2)
                {
                    montoPar = monto / cuotas;
                    cu1 = montoPar + montoGasAdm;
                    cu1Atr = (cu1) * 1.3;
                    cu1Ven = (cu1) * 1.6;
                    cu2 = montoPar;
                    cu2Atr = (cu2) * 1.3;
                    cu2Ven = (cu2) * 1.6;

                    txtCuotaUno.Text = cu1.ToString();
                    txtCuotaUnoAtrasada.Text =cu1Atr.ToString();
                    txtCuotaUnoVencida.Text = cu1Ven.ToString();
                    txtCuotaDos.Text =cu2.ToString();
                    txtCuotaDosAtrasada.Text =cu2Atr.ToString();
                    txtCuotaDosVencida.Text =cu2Ven.ToString();
                }
                else
                {
                    montoPar = monto / cuotas;
                    cu1 = montoPar + montoGasAdm;
                    cu1Atr = (cu1) * 1.3;
                    cu1Ven = (cu1) * 1.6;
                    cu2 = montoPar;
                    cu2Atr = (cu2) * 1.3;
                    cu2Ven = (cu2) * 1.6;
                    cu3 = montoPar;
                    cu3Atr = (cu3) * 1.3;
                    cu3Ven = (cu3) * 1.6;
                    
                    txtCuotaUno.Text = cu1.ToString();
                    txtCuotaUnoAtrasada.Text =  cu1Atr.ToString();
                    txtCuotaUnoVencida.Text =  cu1Ven.ToString();
                    txtCuotaDos.Text =  cu2.ToString();
                    txtCuotaDosAtrasada.Text =  cu2Atr.ToString();
                    txtCuotaDosVencida.Text =  cu2Ven.ToString();
                    txtCuotaTres.Text = cu3.ToString();
                    txtCuotaTresAtrasada.Text = cu3Atr.ToString();
                    txtCuotaTresVencida.Text = cu3Ven.ToString();
                }
            }
            else if(gad.meses==3)
            {
                fgad = montoGasAdm / 3;
                montoPar = monto / cuotas;

                cu1 = montoPar + fgad;
                cu1Atr = (cu1) * 1.3;
                cu1Ven = (cu1) * 1.6;
                cu2 = montoPar + fgad;
                cu2Atr = (cu2) * 1.3;
                cu2Ven = (cu2) * 1.6;
                cu3 = montoPar + fgad;
                cu3Atr = (cu3) * 1.3;
                cu3Ven = (cu3) * 1.6;

                txtCuotaUno.Text = cu1.ToString();
                txtCuotaUnoAtrasada.Text = cu1Atr.ToString();
                txtCuotaUnoVencida.Text =  cu1Ven.ToString();
                txtCuotaDos.Text = cu2.ToString();
                txtCuotaDosAtrasada.Text =  cu2Atr.ToString();
                txtCuotaDosVencida.Text =  cu2Ven.ToString();
                txtCuotaTres.Text =  cu3.ToString();
                txtCuotaTresAtrasada.Text =  cu3Atr.ToString();
                txtCuotaTresVencida.Text =  cu3Ven.ToString();
            }
        }

        //EVENTO PARA EL BOTON CARGAR LAS CUOTAS -->
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            int cuotas = (int)Session["sesionCuotasPrestamo"];
            List<ValorCuota> listaPrecioCuota = new List<ValorCuota>();

            for(int x=0; x<cuotas; x++)
            {
                ValorCuota valor = new ValorCuota();

                if(x==0)
                {
                    valor.numeroCuota = x + 1;
                    valor.valorCuota = float.Parse(txtCuotaUno.Text.ToString());
                    valor.valorCuotaAtrasada = float.Parse(txtCuotaUnoAtrasada.Text.ToString());
                    valor.valorCuotaVencida = float.Parse(txtCuotaUnoVencida.Text.ToString());
                }
                else if(x==1)
                {
                    valor.numeroCuota = x + 1;
                    valor.valorCuota = float.Parse(txtCuotaDos.Text.ToString());
                    valor.valorCuotaAtrasada = float.Parse(txtCuotaDosAtrasada.Text.ToString());
                    valor.valorCuotaVencida = float.Parse(txtCuotaDosVencida.Text.ToString());
                }
                else
                {
                    valor.numeroCuota = x + 1;
                    valor.valorCuota = float.Parse(txtCuotaTres.Text.ToString());
                    valor.valorCuotaAtrasada = float.Parse(txtCuotaTresAtrasada.Text.ToString());
                    valor.valorCuotaVencida = float.Parse(txtCuotaTresVencida.Text.ToString());
                }
                listaPrecioCuota.Add(valor);
            }
            Session.Add("sesionValorCuotaPrestamo", listaPrecioCuota);
            Response.Redirect("AltaPrestamo.aspx");
        }

        //EVENTO DEL BOTON DE LA BARRA PARA IR AL MENU PRINCIPAL --> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrincipalAdm.aspx");
        }
    }
}