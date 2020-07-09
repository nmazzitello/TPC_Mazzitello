using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_MAZZITELLO
{
    public partial class DatosPersonales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["sesionUsuario"];
            Cliente cli = (Cliente)Session["sesionCliente"];

            int adm = (int)Session["soyAdm"];

            if (user == null)
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                ListItem h, i, j;
                h = new ListItem("", "1");
                i = new ListItem("Masculino", "2");
                j = new ListItem("Femenino", "3");
                ddlSexo.Items.Add(h);
                ddlSexo.Items.Add(i);
                ddlSexo.Items.Add(j);

                if (!cli.apellido.Equals("apellidoVacio"))
                {
                    txtApe.Enabled = false;
                    txtNom.Enabled = false;
                    txtDni.Enabled = false;
                    ddlSexo.Enabled = false;
                    txtFechaNac.Enabled = false;
                    ddlNacionalidad.Enabled = false;
                }
                lblNumCliente.Text = "NUMERO CLIENTE: " + cli.idCliente;
                txtApe.Text = cli.apellido;
                txtNom.Text = cli.nombre;
                txtDni.Text = cli.dni;
                if (cli.sexo.Equals("Masculino"))
                {
                    ddlSexo.SelectedIndex = 1;
                }
                else if (cli.sexo.Equals("Femenino"))
                {
                    ddlSexo.SelectedIndex = 2;
                }
                txtFechaNac.Text = cli.fechaNacimiento.ToString("yyyy-MM-dd");
                txtDom.Text = cli.datosDom.direccion;
                txtTel.Text = cli.datosCont.telefonoPrinc;
                txtTelAux.Text = cli.datosCont.telefonoAux;
                txtMail.Text = cli.datosCont.mail;
                if (cli.datosLab.trabaja == true)
                {
                    chbTrabaja.Checked = true;
                }
                txtRubro.Text = cli.datosLab.rubro;
                txtSueldo.Text = cli.datosLab.sueldo.ToString();
                if (cli.datosLab.ingresoExtra == true)
                {
                    chbIngExt.Checked = true;
                }
                txtRazIngExt.Text = cli.datosLab.razonIngresoExtra;
                txtMontoIng.Text = cli.datosLab.montoIngExt.ToString();

                NegocioNacionalidad nn = new NegocioNacionalidad();
                ddlNacionalidad.DataSource = nn.cargarNacionalidades();
                ddlNacionalidad.DataTextField = "nacionalidad";
                ddlNacionalidad.DataValueField = "idNacionalidad";
                ddlNacionalidad.SelectedValue = cli.nacionalidad.idNacionalidad.ToString();
                ddlNacionalidad.DataBind();

                NegocioCiudad nc = new NegocioCiudad();
                ddlCiudad.DataSource = nc.cargarCiudades();
                ddlCiudad.DataTextField = "ciudad";
                ddlCiudad.DataValueField = "idCiudad";
                ddlCiudad.SelectedValue = cli.datosDom.ciudad.idCiudad.ToString();
                ddlCiudad.DataBind();

                NegocioProvincia npr = new NegocioProvincia();
                ddlProvincia.DataSource = npr.cargarProvincias();
                ddlProvincia.DataTextField = "provincia";
                ddlProvincia.DataValueField = "idProvincia";
                ddlProvincia.SelectedValue = cli.datosDom.provincia.idProvincia.ToString();
                ddlProvincia.DataBind();

                NegocioPais np = new NegocioPais();
                ddlPais.DataSource = np.cargarPaises();
                ddlPais.DataTextField = "pais";
                ddlPais.DataValueField = "idPais";
                ddlPais.SelectedValue = cli.datosDom.pais.idPais.ToString();
                ddlPais.DataBind();
            }

            if(adm==1)
            {
                btnAceptar.Text = "VOLVER";
                txtApe.Enabled = false;
                txtNom.Enabled = false;
                txtDni.Enabled = false;
                ddlSexo.Enabled = false;
                txtFechaNac.Enabled = false;
                ddlNacionalidad.Enabled = false;
                txtDom.Enabled = false;
                ddlCiudad.Enabled = false;
                ddlProvincia.Enabled = false;
                ddlPais.Enabled = false;
                txtTel.Enabled = false;
                txtTelAux.Enabled = false;
                txtMail.Enabled = false;
                chbTrabaja.Enabled = false;
                txtRubro.Enabled = false;
                txtSueldo.Enabled = false;
                chbIngExt.Enabled = false;
                txtRazIngExt.Enabled = false;
                txtMontoIng.Enabled = false;
                btnCamUsuCon.Visible = false;
            }
        }

        //EVENTO PARA EL BOTON ACEPTAR --> 100%
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int adm = (int)Session["soyAdm"];
            if (adm == 1)
            {
                Response.Redirect("DetallesCliente.aspx");
            }
            else
            {
                Usuario user = (Usuario)Session["sesionUsuario"];
                Cliente clie = (Cliente)Session["sesionCliente"];

                NegocioCliente nc = new NegocioCliente();
                NegocioNacionalidad na = new NegocioNacionalidad();
                NegocioCiudad nci = new NegocioCiudad();
                NegocioProvincia npr = new NegocioProvincia();
                NegocioPais npa = new NegocioPais();
                Cliente cli = new Cliente();

                cli.idCliente = clie.idCliente;
                cli.cantidadPrestamos = clie.cantidadPrestamos;
                cli.apellido = txtApe.Text;
                cli.nombre = txtNom.Text;
                cli.dni = txtDni.Text;
                if (ddlSexo.SelectedIndex == 1)
                {
                    cli.sexo = "Masculino";
                }
                if (ddlSexo.SelectedIndex == 2)
                {
                    cli.sexo = "Femenino";
                }
                if (ddlSexo.SelectedIndex == 0)
                {
                    cli.sexo = "Pendiente";
                }
                cli.fechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
                Nacionalidad nac = na.traerNac(int.Parse(ddlNacionalidad.SelectedItem.Value));
                cli.nacionalidad = nac;

                DatosDomicilio dd = new DatosDomicilio();
                dd.direccion = txtDom.Text.ToString();
                Ciudad ciu = nci.traerCiu(long.Parse(ddlCiudad.SelectedItem.Value));
                dd.ciudad = ciu;
                Provincia pro = npr.traerProv(long.Parse(ddlProvincia.SelectedItem.Value));
                dd.provincia = pro;
                Pais pai = npa.traerPais(int.Parse(ddlPais.SelectedItem.Value));
                dd.pais = pai;
                cli.datosDom = dd;

                DatosContacto dc = new DatosContacto();
                dc.telefonoPrinc = txtTel.Text;
                dc.telefonoAux = txtTelAux.Text;
                dc.mail = txtMail.Text;
                cli.datosCont = dc;

                DatosLaborales dl = new DatosLaborales();

                if (chbTrabaja.Checked == true)
                {
                    dl.trabaja = true;
                }
                else
                {
                    dl.trabaja = false;
                }
                dl.rubro = txtRubro.Text;
                double sueldoConDec = double.Parse(txtSueldo.Text);
                int sueldo = (int)sueldoConDec;
                dl.sueldo = sueldo.ToString();
                if (chbIngExt.Checked == true)
                {
                    dl.ingresoExtra = true;
                }
                else
                {
                    dl.ingresoExtra = false;
                }
                dl.razonIngresoExtra = txtRazIngExt.Text;
                double ingExtConDec = double.Parse(txtMontoIng.Text);
                int ingExt = (int)ingExtConDec;
                dl.montoIngExt = ingExt.ToString();
                cli.datosLab = dl;

                if (nc.sePuedeGuardar(cli) == true)
                {
                    nc.guardarCliente(cli, cli.idCliente);
                    Session.Add("sesionCliente", cli);
                    Response.Redirect("AccionExitosa.aspx");

                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Debes completar todos los campos para continuar.');", true);
            }
        }

        //EVENTO PARA EL BOTON QUE LLEVA A CAMBIAR LOS DATOS DE INICIO SESION --> 100%
        protected void btnCamUsuCon_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarDatosUsuario.aspx");
        }

        //EVENTO PARA EL BOTON DE LA BARRA QUE LLEVA AL INICIO --> 100%
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            int adm = (int)Session["soyAdm"];

            if(adm==0)
            {
                Response.Redirect("PrincipalCliente.aspx");
            }
            Response.Redirect("PrincipalAdm.aspx");
        }

    }
}