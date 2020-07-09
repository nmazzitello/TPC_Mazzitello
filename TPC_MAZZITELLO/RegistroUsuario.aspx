<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="TPC_MAZZITELLO.RegistroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro usuario</title>

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
                Text="INICIO" OnClick="btnInicio_Click" />
        </div>
        
            <h1 class="centrar titulo">
                CREAR CUENTA
            </h1>
       
        <div class="centrar">
            <div>
                <p>Usuario:</p>
                <asp:TextBox ID="txtUsu" runat="server" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
                <p>Contraseña:</p>
                <asp:TextBox ID="txtContra" runat="server" TextMode="Password" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
                <p>Repetir contraseña:</p>
                <asp:TextBox ID="txtRepContra" runat="server" TextMode="Password" MaxLength="28" CssClass="cajaTexto"></asp:TextBox>
            </div>
        
            <asp:Button ID="btnAceptar" runat="server" 
                Text="ACEPTAR" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-lg botonn"/>
        </div>

    </form>
</body>
</html>
