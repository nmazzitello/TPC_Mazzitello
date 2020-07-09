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
    public partial class AltaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente cli = (Cliente)Session["sesionCliente"];

            Usuario user = (Usuario)Session["sesionUsuario"];
            if (user == null)
            {
                Response.Redirect("index.aspx");
            }

            int chk = 0;
            if (Session["sesionCheck"] != null)
            {
                chk = (int)Session["sesionCheck"];  //variable que se crea en el evento btnCheck en verSolicitudes
            }

            NegocioProducto np = new NegocioProducto();
            Producto pro = new Producto();


            if (chk == 1)
            {
                lblTituloAgregarProd.Text = "DETALLES PRODUCTO";
                long idNecesario=0;

                if (Session["sessionVerPrestamo"]!= null)
                {
                    idNecesario = (long)Session["sessionVerPrestamo"];   //sesion generada en  VerPrestamo en el evento btnVer_click
                    NegocioPrestamo npr = new NegocioPrestamo();
                    Prestamo pre = new Prestamo();
                    pre = npr.cargarPrestamo(idNecesario);
                    pro = np.cargarProducto(pre.prodGarantia.idProducto);

                }
                else if(Session["sessionIdSolicitud"]!=null)
                {
                    idNecesario = (long)Session["sessionIdSolicitud"];
                    NegocioSolicitud ns = new NegocioSolicitud();
                    Solicitud sol = new Solicitud();
                    sol = ns.cargarSolicitud(idNecesario);
                    pro = np.cargarProducto(sol.producto.idProducto);
                }
                
                repeaterProducto.Visible = false;
                txtProducto.Text = pro.producto;
                txtProducto.Enabled = false;
                txtDetalles.Text=pro.detalles;
                txtDetalles.Enabled = false;
                txtImagen.Text= pro.imagen;
                txtImagen.Enabled = false;
                txtModelo.Text=pro.modelo;
                txtModelo.Enabled = false;
                imgProd.ImageUrl = txtImagen.Text;

                ListItem h, i;
                h = new ListItem("Usado", "1");
                i = new ListItem("Nuevo", "2");
                ddlEstado.Items.Add(h);
                ddlEstado.Items.Add(i);
                if (pro.estado.Equals("Usado"))
                {
                    ddlEstado.SelectedIndex = 0;
                }
                else
                {
                    ddlEstado.SelectedIndex = 1;
                }
                ddlEstado.Enabled = false;
                txtMarca.Text = pro.marca;
                txtMarca.Enabled = false;
                txtModelo.Text=pro.modelo;
                txtModelo.Enabled = false;
                btnAceptar.Visible = false;
            }
            else
            {
                if (!IsPostBack)
                {
                    NegocioProducto npo = new NegocioProducto();
                    ListItem h, i;
                    h = new ListItem("Usado", "1");
                    i = new ListItem("Nuevo", "2");
                    ddlEstado.Items.Add(h);
                    ddlEstado.Items.Add(i);

                    repeaterProducto.DataSource = npo.traerProductos(cli.idCliente);
                    repeaterProducto.DataBind();
                }

                int prestamoActivo = (int)Session["sesionPrestamoEnProgreso"];
                if (prestamoActivo == 1)
                {
                    lblTituloAgregarProd.Visible = false;
                    lblProducto.Visible = false;
                    lblDetalles.Visible = false;
                    lblImagen.Visible = false;
                    lblEstado.Visible = false;
                    lblMarca.Visible = false;
                    lblModelo.Visible = false;
                    txtProducto.Visible = false;
                    txtDetalles.Visible = false;
                    txtImagen.Visible = false;
                    txtModelo.Visible = false;
                    ddlEstado.Visible = false;
                    txtMarca.Visible = false;
                    txtModelo.Visible = false;
                    btnAceptar.Visible = false;
                }
            }
        }

        //EVENTO PARA EL BOTON ACEPTAR Y AGREGAR UN PRODUCTO AL CLIENTE --> 100%
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            Cliente cli = (Cliente)Session["sesionCliente"];

            prod.producto = txtProducto.Text.Trim();
            prod.marca = txtMarca.Text.Trim();
            prod.modelo = txtModelo.Text.Trim();
            prod.detalles = txtDetalles.Text.Trim();
            if(ddlEstado.SelectedIndex==0)
            {
                prod.estado = "Usado";
            }
            if (ddlEstado.SelectedIndex == 1)
            {
                prod.estado = "Nuevo";
            }
            prod.imagen = txtImagen.Text;

            NegocioProducto npr = new NegocioProducto();
            if(npr.agregrarProducto(prod, cli.idCliente)==true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Se agrego el producto correctamente.');", true);
                Response.Redirect("AltaProducto.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Fallo al cargar, intente de nuevo, o comuniquese con el 11-1111-1111.');", true);
            }
        }

        //EVENTO DEL BOTON SELECCIONAR DEL GRIDVIEW --> 100%
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            NegocioProducto np = new NegocioProducto();
            Producto prod = new Producto();
            long idEsco = Convert.ToInt64(((Button)sender).CommandArgument);
            prod = np.cargarProducto(idEsco);

            if (Session["sessionVerProductos"] != null)
            {
                int verPro = 0;
                verPro = (int)Session["sessionVerProductos"]; //session que se carga en principalCliente
                if (verPro == 1)
                {
                    txtProducto.Text = prod.producto;
                    //txtProducto.Enabled = false;
                    txtDetalles.Text = prod.detalles;
                    //txtDetalles.Enabled = false;
                    txtImagen.Text = prod.imagen;
                    //txtImagen.Enabled = false;
                    txtModelo.Text = prod.modelo;
                    //txtModelo.Enabled = false;
                    if (prod.estado.Equals("Usado"))
                    {
                        ddlEstado.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlEstado.SelectedIndex = 1;
                    }
                    //ddlEstado.Enabled = false;
                    txtMarca.Text = prod.marca;
                    //txtMarca.Enabled = false;
                    txtModelo.Text = prod.modelo;
                    //txtModelo.Enabled = false;
                    //btnAceptar.Visible = false;
                    
                }
            }
            else
            {
                int prestamoActivo = (int)Session["sesionPrestamoEnProgreso"];
                if (prestamoActivo == 1)
                {
                    Session.Add("sesionProductoPrestamo", prod); // se carga el producto que se va a usar para el prestamo y vuelve a altaPrestamo
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Producto cargado con exito.');", true);
                    Response.Redirect("AltaPrestamo.aspx");
                }
                else
                {
                    Session.Add("sesionProducto", prod);
                    Response.Redirect("AltaSolicitudPrestamo.aspx");
                }
            }
        }

        //EVENTO DEL BOTON DE LA BARRA QUE LLEVA AL INICIO --> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Session.Remove("sesionCheck");
            Session.Remove("sessionIdSolicitud");
            Session.Remove("sessionVerProductos");
            Session.Remove("sessionVerPrestamo");
            Session.Remove("sesionPrestamoEnProgreso");
            Session.Remove("sessionVerProductos");
            Session.Remove("sesionProductoPrestamo");
            Session.Remove("sesionProducto");

            int adm = (int)Session["soyAdm"];
            if (adm == 0)
            {
                Response.Redirect("PrincipalCliente.aspx");
            }
            Response.Redirect("PrincipalAdm.aspx");
        }
    }
}