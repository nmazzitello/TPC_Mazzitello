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
    public partial class CambiarDatosUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = (Usuario)Session["sesionUsuario"];
            lblUsuarioActual.Text = usu.nombre;

            int adm = (int)Session["soyAdm"];
            if(adm==1)
            {
                btnEliminar.Visible = false;    
            }
        }

        //EVENTO DEL BOTON ELIMINAR QUE BORRA LOGICAMENTE LA CUENTA --> 
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario usu = (Usuario)Session["sesionUsuario"];
            NegocioUsuario nu = new NegocioUsuario();

            if (txtContra.Text.Equals(usu.contasenia))
            {
                nu.eliminarUsuario(usu.idUsuario);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Usuario eliminado');", true);
                Response.Redirect("index.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Contraseña equivocada');", true);
            }
        }

        //EVENTO PARA EL BOTON ACEPTAR QUE MODIFICA EL NOMBRE O CONTRASEÑA DEL USUARIO --> 100%
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usu = (Usuario)Session["sesionUsuario"];
            NegocioUsuario nu = new NegocioUsuario();

            if (!txtUsu.Text.Equals("")) //si cambio el usuario
            {
                if (txtContra.Text.Equals(usu.contasenia))
                {
                    if(nu.modificarNombreUsuario(txtUsu.Text, usu.idUsuario)==true)
                    {
                        usu.nombre = txtUsu.Text;
                        Session.Add("sesionUsuario", usu);
                        
                        Response.Redirect("AccionExitosa.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Nombre de usuario ya existe');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Contraseña equivocada');", true);
                }
            }
            else if(txtContraNue.Text.Equals(txtContraNue2.Text))
            {
                if (txtContra.Text.Equals(usu.contasenia))
                {
                    nu.modificarContraUsuario(txtContraNue.Text, usu.idUsuario);
                    usu.contasenia = txtContra.Text;
                    Session.Add("sesionUsuario", usu);

                    Response.Redirect("AccionExitosa.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Contraseña equivocada');", true);
                }
            }
        }

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