using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPC_MAZZITELLO
{
    public partial class iniciarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //EVENTO PARA EL BOTON ACEPTAR --> 30%
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            NegocioUsuario nu = new NegocioUsuario();
            Usuario user = new Usuario();
            String usu = txtUsuario.Text;
            String con = txtContra.Text;

            user = nu.cargarUsuario(usu, con);
            if(!usu.Equals("") && !con.Equals(""))
            {
                if (user != null)
                {
                    if (user.activo == true)
                    {
                        if (user.tipoUsuario.idTipoUsuario == 1)
                        {
                            Session.Add("soyAdm", 1);
                            Session.Add("sesionUsuario", user);
                            Response.Redirect("PrincipalAdm.aspx");
                        }
                        else
                        {
                            Cliente cli = new Cliente();
                            NegocioCliente nc = new NegocioCliente();
                            cli = nc.cargarCliente(user);

                            Session.Add("soyAdm", 0);
                            Session.Add("sesionCliente", cli);
                            Session.Add("sesionUsuario", user);
                            Response.Redirect("PrincipalCliente.aspx");
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Cuenta inhabilitada, comuniquese con el numero 11-1111-1111');", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Contraseña/usuario incorrecta');", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Debes completar todos los campos para continuar.');", true);
        }

    }
}