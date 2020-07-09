using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_MAZZITELLO
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //EVENTO AL PRESIONAR EL BOTON ACEPTAR EN CREAR USUARIO --> %
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            String user, pass, doublePass;
            user = txtUsu.Text;
            pass = txtContra.Text;
            doublePass = txtRepContra.Text;

            if (!user.Equals("") || !pass.Equals("") || !doublePass.Equals(""))
            {
                if (pass.Equals(doublePass))
                {
                    NegocioUsuario nu = new NegocioUsuario();

                    if (nu.buscarNombreUsuario(user) == false)
                    {
                        nu.agregarUsuario(user, pass);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El usuario se creo exitosamente');", true);

                        Usuario uu = new Usuario();
                        uu = nu.cargarUsuario(user, pass);
                        Cliente cli = new Cliente();
                        NegocioCliente nc = new NegocioCliente();
                        cli = nc.cargarCliente(uu);

                        Session.Add("soyAdm", 0);
                        Session.Add("sesionCliente", cli);
                        Session.Add("sesionUsuario", uu);
                        Response.Redirect("PrincipalCliente.aspx");
                    }
                    // nombre usuario existe
                    //txtUsu.BackColor = Color.Red;
                    //txtUsu.Text = "";
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Las contraseñas no coinciden');", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Debe completar todos los campos para continuar');", true);
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}