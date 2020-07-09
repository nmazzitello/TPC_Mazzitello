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
    public partial class SimulacionPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente cli = (Cliente)Session["sesionCliente"];
            if (cli == null)
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                ListItem h, i, j;
                h = new ListItem("1", "1");
                i = new ListItem("2", "2");
                j = new ListItem("3", "3");
                ddlCantCuot.Items.Add(h);
                ddlCantCuot.Items.Add(i);
                ddlCantCuot.Items.Add(j);

                NegocioGastosAdm nga = new NegocioGastosAdm();
                ddlGastosAdm.DataSource = nga.traerGastosAdm();
                ddlGastosAdm.DataTextField = "detalles";
                ddlGastosAdm.DataValueField = "idGastosAdm";
                ddlGastosAdm.DataBind();
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            if(!txtMonto.Text.Equals(""))
            {
                double monto = (Int32.Parse(txtMonto.Text)) * 1.5;
                int meses = (ddlCantCuot.SelectedIndex) + 1;
                int recargoGasAdm;
                if (int.Parse(ddlGastosAdm.SelectedItem.Value) == 1)
                {
                    recargoGasAdm = 500;
                }
                else
                {
                    recargoGasAdm = 1000;
                }
                double resultado = (monto + recargoGasAdm) / meses;
                lblPagar.Text = "El valor total es de: $" + (monto + recargoGasAdm) + "Y valor de cada cuota es: $" + resultado.ToString() + ". Que corresponde al monto solicitado: $" + txtMonto.Text + ", mas el interes del credito: $" + monto / 3 + ", mas los gastos administrativos: $" + recargoGasAdm;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese el monto.');", true);
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrincipalCliente.aspx");
        }
    }
}