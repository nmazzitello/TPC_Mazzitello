<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="TPC_MAZZITELLO.DatosPersonales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DATOS PERSONALES</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <link href="estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="barra">
            <asp:Button runat="server"
                ID="btnInicio"
                CssClass="btn btn-dark float-right botonIngresar"
                Text="Inicio" OnClick="btnInicio_Click" />
        </div>

       
         <div>
            <h2 class="centrar titulo">DATOS PERSONALES</h2>
            <section class="centrar ">
                <div class="recuadro botonn label" >
                    <asp:Label ID="lblNumCliente" runat="server" Text="NUMERO CLIENTE: "></asp:Label>
                </div>
                
                <p>Apellido:</p>
                <asp:TextBox ID="txtApe" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
                <p>Nombre:</p>
                <asp:TextBox ID="txtNom" runat="server" MaxLength="28"  CssClass="cajaTexto"></asp:TextBox>
                <p>DNI:</p>
                <asp:TextBox ID="txtDni" runat="server" TextMode="Number" MaxLength="10" CssClass="cajaTexto"></asp:TextBox>
                <p>Sexo:</p>
                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="cajaTexto"></asp:DropDownList>
                <p>Fecha nacimiento:</p>
                <asp:TextBox ID="txtFechaNac" runat="server" TextMode="Date" CssClass="cajaTexto"></asp:TextBox>
                <p>Nacionalidad:</p>
                <asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="cajaTexto"></asp:DropDownList>
                <hr class="centrar" />
                <p>Domicilio:</p>
                <asp:TextBox ID="txtDom" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
                <p>Ciudad:</p>
                <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="cajaTexto"></asp:DropDownList>
                <p>Provincia:</p>
                <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="cajaTexto"></asp:DropDownList>
                <p>País:</p>
                <asp:DropDownList ID="ddlPais" runat="server" CssClass="cajaTexto"></asp:DropDownList>
                <hr class="centrar" />
                <p>Teléfono:</p>
                <asp:TextBox ID="txtTel" runat="server" TextMode="Number" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
                <p>Teléfono auxiliar:</p>
                <asp:TextBox ID="txtTelAux" runat="server" TextMode="Number" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
                <p>Mail</p>
                <asp:TextBox ID="txtMail" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
            </section>
        </div>

        <div>
            <h2 class="centrar titulo">DATOS FINANCIEROS</h2>
            <section class="centrar botonn">
                <asp:Label ID="lblTrabaja" runat="server" Text="Trabaja:" CssClass="label"></asp:Label>
                <asp:CheckBox ID="chbTrabaja" runat="server"/>
                <p>Rubro:</p>
                <asp:TextBox ID="txtRubro" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
                <p>Sueldo:</p>
                <asp:TextBox ID="txtSueldo" runat="server"  MaxLength="6" CssClass="cajaTexto"></asp:TextBox><br /> <br />
                <hr class="centrar" />
                <asp:Label ID="lblIngExt" runat="server" Text="Ingreso extra" CssClass="label"></asp:Label>
                <asp:CheckBox ID="chbIngExt" runat="server"/>
                <p>Razón ingreso extra:</p>
                <asp:TextBox ID="txtRazIngExt" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
                <p>Monto ingreso extra:</p>
                <asp:TextBox ID="txtMontoIng" runat="server" MaxLength="6" CssClass="cajaTexto"></asp:TextBox>
            </section>
        </div>

        <div class="centrar2">
            <asp:Button ID="btnCamUsuCon" runat="server" 
            Text="Cambiar usuario o contraseña" OnClick="btnCamUsuCon_Click" CssClass="btn btn-secondary btn-lg botonn"/><br /> <br />
        <asp:Button ID="btnAceptar" runat="server"
            Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-lg botonn "/>
        </div>

    </form>
</body>
</html>

 <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
            runat="server" ErrorMessage="Debe ingresar solo letras." 
            ControlToValidate="txtSoloLetras" ValidationExpression="^[a-zA-Z]*$" 
            ValidationGroup="SOLOLETRAS"></asp:RegularExpressionValidator>    chequear para validar solo letras   --%>


