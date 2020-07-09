using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_MAZZITELLO
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //METODO QUE LLEVA A INICIAR SESION --> 100%
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("iniciarSesion.aspx");
        }
    }
}