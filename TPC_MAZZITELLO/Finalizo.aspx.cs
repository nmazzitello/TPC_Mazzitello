using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_MAZZITELLO
{
    public partial class Finalizo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinuar_Click(object sender, EventArgs e)
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