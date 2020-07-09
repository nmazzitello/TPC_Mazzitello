<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarDatosUsuario.aspx.cs" Inherits="TPC_MAZZITELLO.CambiarDatosUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DATOS INICIO SESION</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <link href="estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div>

            <div class="barra">
            <asp:Button runat="server"
                ID="btnInicio"
                CssClass="btn btn-dark float-right botonIngresar"
                Text="Inicio" OnClick="btnInicio_Click" />
            </div>

                <h2 class="centrar titulo2">
                    INICIO SESION
                </h2>

            <div class="centrar">  
                <p>Usuario actual: <asp:Label ID="lblUsuarioActual" runat="server" Text="Label"></asp:Label></p>
                
                <p>Nuevo nombre de usuario:</p>
                <asp:TextBox ID="txtUsu" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>

                <p>Contraseña nueva:</p>
                <asp:TextBox ID="txtContraNue" runat="server" TextMode="Password" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>

                <p>Repetir contraseña nueva:</p>
                <asp:TextBox ID="txtContraNue2" runat="server" TextMode="Password" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>

                <p>Contraseña actual:</p>
                <asp:TextBox ID="txtContra" runat="server" TextMode="Password" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
            </div>

            <div class="centrar">
                <asp:Button ID="btnEliminar" runat="server"
                    Text="ELIMINAR CUENTA" OnClick="btnEliminar_Click" CssClass="btn btn-secondary btn-lg botonn "/><br /> <br />
            
            <asp:Button ID="btnAceptar" runat="server"
                    Text="ACEPTAR" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-lg botonn"/>
            </div>
        </div>
    </form>
</body>
</html>
